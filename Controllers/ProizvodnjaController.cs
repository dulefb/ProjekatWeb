using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Proba1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodnjaController : ControllerBase
    {
        private DestilerijaContext Context { get; set; }

        public ProizvodnjaController(DestilerijaContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("RadniciRadiliNa/{bureID}")]
        public async Task<ActionResult> RadniciRadiliNa(int bureID)
        {
            var radnici=Context.Proizvodnja
                                .Include(p=> p.Radnik);
            
            try
            {
                var lista=await radnici.Where(p=> p.Burad.ID==bureID ).ToListAsync();

                if(lista==null){
                    throw new Exception("Nije pronadjena ni jedna proizvodnja.");
                }

                if(lista.Count==0){
                    throw new Exception("Nije pronadjena ni jedna proizvodnja.");
                } 
                return Ok(lista.Select(p=> new {
                    ID=p.Radnik.ID,
                    Ime=p.Radnik.Ime,
                    Prezime=p.Radnik.Prezime
                }));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajRadnikaNaProizvodnju/{bureID}/{radnikID}")]
        [HttpPost]
        public async Task<ActionResult> DodajRadnikaNaProizvodnju(int bureID,int radnikID)
        {
            try
            {
                var burad= await Context.Burad.FindAsync(bureID);
                if(burad==null)
                    throw new Exception($"Bure sa ID: {bureID} nije nadjeno.");

                var radnik= await Context.Radnik.FindAsync(radnikID);
                if(radnik==null)
                    throw new Exception($"Radnik sa ID: {radnikID} nije pronadjen.");
                
                Proizvodnja p1=new Proizvodnja();
                p1.Burad=burad;
                p1.Radnik=radnik;
                Context.Proizvodnja.Add(p1);
                await Context.SaveChangesAsync();

                return Ok($"Veza je dodata.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiProizvodnju/{BuradId}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiProizvodnju(int BuradId)
        {
            try
            {
                var pom=Context.Proizvodnja.Where(x=>x.Burad.ID==BuradId).ToList();
                if(pom==null)
                    throw new Exception("Nije pronadjeno ni jedno bure u proizvodnji");
                
                foreach(var el in pom){
                    Context.Proizvodnja.Remove(el);
                }
                await Context.SaveChangesAsync();
                return Ok("Proizvodnja je obrisana");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}