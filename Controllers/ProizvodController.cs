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
    public class ProizvodController : ControllerBase
    {

        private DestilerijaContext Context {get; set;}
        public ProizvodController(DestilerijaContext context)
        {
            Context = context;
        }

        [HttpPost]
        [Route("DodajProizvod/{naziv}")]
        public async Task<ActionResult> DodajProizvod(string naziv)
        {
            Proizvod pom=new Proizvod();
            pom.Naziv=naziv;

            try
            {
                Context.Proizvod.Add(pom);
                await Context.SaveChangesAsync();
                return Ok($"Proizvod je dodat.");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("VratiProizvode")]
        public ActionResult VratiProizvode()
        {
            try
            {
                var proizvod=Context.Proizvod;
                return Ok(proizvod.Select(p=> new {
                    Id=p.ID,
                    Naziv=p.Naziv
                }
                ));
            }
            catch
            {
                return BadRequest("Prozivodi neuspesno vraceni!");
            }
        }
    }
}