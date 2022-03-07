using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRecibos.Models;
using ApiRecibos.Repositories;

namespace ApiRecibos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecibosController : ControllerBase
    {
        RecibosContext context = new RecibosContext();


        [HttpGet]
        public ActionResult Get()
        {
            RecibosRepository repository = new RecibosRepository(context);
            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Recibo> GetRecibo(int id)
        {
            RecibosRepository repository = new RecibosRepository(context);
            return Ok(repository.GetReciboById(id));
        }

        [HttpPost]
        public ActionResult<Recibo> AgregarRecibo(Recibo recibo)
        {
            RecibosRepository repository = new RecibosRepository(context);
            repository.Create(recibo);

            return CreatedAtAction(nameof(GetRecibo), new { id = recibo.Id }, recibo);
        }

        [HttpPut("{id}")]
        public ActionResult EditarRecibo(int id, Recibo recibo)
        {
            if (id != recibo.Id)
                return BadRequest();

            RecibosRepository repository = new RecibosRepository(context);
            repository.Update(id, recibo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult BorrarRecibo(int id)
        {
            RecibosRepository repository = new RecibosRepository(context);
            repository.Delete(id);

            return NoContent();
        }
    }
}
