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
    public class EntradasController : ApiController
    {
        private ExamenPivContext db = new ExamenPivContext("ExamenPIV");

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return db.Entradas;
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(int id)
        {
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(int id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.Id)
            {
                return BadRequest();
            }

            db.Entry(entrada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaExists(id))
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

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entradas.Add(entrada);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entrada.Id }, entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(int id)
        {
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return NotFound();
            }

            db.Entradas.Remove(entrada);
            db.SaveChanges();

            return Ok(entrada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntradaExists(int id)
        {
            return db.Entradas.Count(e => e.Id == id) > 0;
        }
    }
}