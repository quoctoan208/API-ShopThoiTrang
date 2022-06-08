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
    public class GIOHANGsController : ApiController
    {
        private Doan4_SHOPEntities1 db = new Doan4_SHOPEntities1();

        // GET: api/GIOHANGs
        public IQueryable<GIOHANG> GetGIOHANGs()
        {
            return db.GIOHANGs;
        }

        // GET: api/GIOHANGs/5
        [ResponseType(typeof(GIOHANG))]
        public IHttpActionResult GetGIOHANG(string id)
        {
            GIOHANG gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return NotFound();
            }

            return Ok(gIOHANG);
        }

        // PUT: api/GIOHANGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGIOHANG(string id, GIOHANG gIOHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gIOHANG.ID)
            {
                return BadRequest();
            }

            db.Entry(gIOHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GIOHANGExists(id))
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

        // POST: api/GIOHANGs
        [ResponseType(typeof(GIOHANG))]
        public IHttpActionResult PostGIOHANG(GIOHANG gIOHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GIOHANGs.Add(gIOHANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GIOHANGExists(gIOHANG.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gIOHANG.ID }, gIOHANG);
        }

        // DELETE: api/GIOHANGs/5
        [ResponseType(typeof(GIOHANG))]
        public IHttpActionResult DeleteGIOHANG(string id)
        {
            GIOHANG gIOHANG = db.GIOHANGs.Find(id);
            if (gIOHANG == null)
            {
                return NotFound();
            }

            db.GIOHANGs.Remove(gIOHANG);
            db.SaveChanges();

            return Ok(gIOHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GIOHANGExists(string id)
        {
            return db.GIOHANGs.Count(e => e.ID == id) > 0;
        }
    }
}