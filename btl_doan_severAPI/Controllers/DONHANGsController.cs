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
using btl_doan_severAPI.Models;

namespace btl_doan_severAPI.Controllers
{
    public class DONHANGsController : ApiController
    {
        private Doan4_SHOPEntities1 db = new Doan4_SHOPEntities1();

        // GET: api/DONHANGs
        public IQueryable<DONHANG> GetDONHANGs()
        {
            return db.DONHANGs;
        }

        // GET: api/DONHANGs/5
        [ResponseType(typeof(DONHANG))]
        public IHttpActionResult GetDONHANG(string id)
        {
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return NotFound();
            }

            return Ok(dONHANG);
        }

        // PUT: api/DONHANGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDONHANG(string id, DONHANG dONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dONHANG.maDH)
            {
                return BadRequest();
            }

            db.Entry(dONHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DONHANGExists(id))
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

        // POST: api/DONHANGs
        [ResponseType(typeof(DONHANG))]
        public IHttpActionResult PostDONHANG(DONHANG dONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DONHANGs.Add(dONHANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DONHANGExists(dONHANG.maDH))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dONHANG.maDH }, dONHANG);
        }

        // DELETE: api/DONHANGs/5
        [ResponseType(typeof(DONHANG))]
        public IHttpActionResult DeleteDONHANG(string id)
        {
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return NotFound();
            }

            db.DONHANGs.Remove(dONHANG);
            db.SaveChanges();

            return Ok(dONHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DONHANGExists(string id)
        {
            return db.DONHANGs.Count(e => e.maDH == id) > 0;
        }
    }
}