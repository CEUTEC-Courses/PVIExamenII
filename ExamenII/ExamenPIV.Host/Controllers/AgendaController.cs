using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ExamenPIV.Data;
using ExamenPIV.Data.Modelos;

namespace ExamenPIV.Host.Controllers
{
    public class AgendaController : ApiController
    {
        private ExamenPivContext examenPivContext = new ExamenPivContext("ExamenPIV");

        // GET: api/Agenda
        public IQueryable<Agenda> GetAgenda()
        {
            return examenPivContext.Agendas.Include("Entradas");
        }

        // GET: api/Agenda/5
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult GetAgenda(int id)
        {
            Agenda agenda = examenPivContext.Agendas.Find(id);
            if (agenda == null)
            {
                return NotFound();
            }

            return Ok(agenda);
        }

        // PUT: api/Agenda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgenda(int id, Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenda.Id)
            {
                return BadRequest();
            }

            examenPivContext.Entry(agenda).State = EntityState.Modified;

            try
            {
                examenPivContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Agenda
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult PostAgenda(Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            examenPivContext.Agendas.Add(agenda);
            examenPivContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agenda.Id }, agenda);
        }

        // DELETE: api/Agenda/5
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult DeleteAgenda(int id)
        {
            Agenda agenda = examenPivContext.Agendas.Find(id);
            if (agenda == null)
            {
                return NotFound();
            }

            examenPivContext.Agendas.Remove(agenda);
            examenPivContext.SaveChanges();

            return Ok(agenda);
        }

        [ResponseType(typeof(Agenda))]
        [HttpPut]
        [Route("api/Agenda/{idAgenda}/Entrada/{idEntrada}")]
        public IHttpActionResult AgregarLibro(int idAgenda, int idEntrada)
        {
            var agenda = examenPivContext.Agendas.Find(idAgenda);
            var entrada = examenPivContext.Entradas.Find(idEntrada);

            if (agenda == null || entrada == null)
            {
                return NotFound();
            }

            agenda.AgregarEntrada(entrada);

            examenPivContext.Entry(agenda).State =
                EntityState.Modified;

            examenPivContext.SaveChanges();
            return Ok(agenda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                examenPivContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgendaExists(int id)
        {
            return examenPivContext.Agendas.Count(e => e.Id == id) > 0;
        }
    }
}