using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace Proba1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuradController : ControllerBase
    {

        private DestilerijaContext Context {get; set;}
        public BuradController(DestilerijaContext context)
        {
            Context = context;
        }

        [Route("DodajBurad/{kolicina}/{godina}/{idProizvod}")]
        [HttpPost]
        public async Task<ActionResult> DodajBurad(int kolicina,int godina,int idProizvod)
        {
            try
            {
                var proizvod=Context.Proizvod.Where(p=>p.ID==idProizvod).FirstOrDefault();
                if(proizvod==null)
                    throw new Exception("Proizvod sa ID=" + idProizvod + " nije pronadjen");
                Burad b1=new Burad();
                b1.Kolicina=kolicina;
                b1.Godina=godina.ToString();
                b1.Proizvod=proizvod;
                Context.Burad.Add(b1);
                await Context.SaveChangesAsync();
                return Ok(b1.ID);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("VratiBurad")]
        [HttpGet]
        public ActionResult VratiBurad()
        {
            var bure=Context.Burad;
            return Ok(bure.Select(p=>new{
                ID=p.ID,
                Kolicina=p.Kolicina,
                Godina=p.Godina,
                Naziv=p.Proizvod.Naziv
                /*Proizvodnja=p.Proizvodnja.Select(e=>new {
                    ID=e.Radnik.ID,
                    Ime=e.Radnik.Ime,
                    Prezime=e.Radnik.Prezime
                })*/
            })
            );
        }

        [Route("ObrisiBure/{bureID}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiBure(int bureID)
        {
            try
            {
                var bure=await Context.Burad.FindAsync(bureID);
                if(bure==null)
                    throw new Exception("Bure nije nadjeno.");
                
                Context.Burad.Remove(bure);
                await Context.SaveChangesAsync();
                return Ok("Bure je obrisano.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [Route("IzmeniBurad/{id}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniBurad(int id,int kolicina,int godina,int idProizvod)
        {
            try
            {
                var pom=Context.Burad.Where(x=>x.ID==id).FirstOrDefault();
                if(pom==null)
                    throw new Exception("Bure nije pronadjeno.");
                
                var proizvod=Context.Proizvod.Where(x=>x.ID==idProizvod).FirstOrDefault();
                if(proizvod==null)
                    throw new Exception("Proizvod nije pronadjen");

                pom.Kolicina=kolicina;
                pom.Godina=godina.ToString();
                pom.Proizvod=proizvod;
                await Context.SaveChangesAsync();

                return Ok("Bure je izmenjeno.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
