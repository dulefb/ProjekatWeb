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
    public class RadnikController : ControllerBase
    {
        private DestilerijaContext Context {get; set;}

        public RadnikController(DestilerijaContext context)
        {
            Context=context;
        }

        [HttpGet]
        [Route("VratiRadnika")]
        public ActionResult VratiRadnika()
        {
            try
            {
                var radnici = Context.Radnik
                            .Include(p => p.Proizvodnja)
                            .ThenInclude(e => e.Burad);

                return Ok(radnici.Select(p=> new{
                    ID=p.ID,
                    Ime=p.Ime,
                    Prezime=p.Prezime
                }));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajRadnika")]
        [HttpPost]
        public async Task<ActionResult> DodajRadnika([FromBody] Radnik r1)
        {
            try
            {
            Context.Radnik.Add(r1);
            await Context.SaveChangesAsync();
            return Ok("Radnik je dodat.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ObrisiRadnika/{id}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiRadnika(int id)
        {
            try
            {
                var radnik = Context.Radnik.Where(p=>p.ID==id).FirstOrDefault();
                Context.Radnik.Remove(radnik);
                await Context.SaveChangesAsync();
                return Ok($"Radnik sa ID: {id} je obrisan");
            }
            catch(Exception e)
            {
                return BadRequest("Radnik sa ID: "+id+" ne postoji\n"+e.Message);
            }
        }
    }
}