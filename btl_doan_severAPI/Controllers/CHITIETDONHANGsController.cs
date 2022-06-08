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
    public class CHITIETDONHANGsController : ApiController
    {
        private Doan4_SHOPEntities1 db = new Doan4_SHOPEntities1();

        // GET: api/CHITIETDONHANGs
        public IQueryable<CHITIETDONHANG> GetCHITIETDONHANGs()
        {
            return db.CHITIETDONHANGs;
        }

        // GET: api/CHITIETDONHANGs/5
        [ResponseType(typeof(CHITIETDONHANG))]
        public IHttpActionResult GetCHITIETDONHANG(string id)
        {
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return NotFound();
            }

            return Ok(cHITIETDONHANG);
        }

        // PUT: api/CHITIETDONHANGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCHITIETDONHANG(string id, CHITIETDONHANG cHITIETDONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cHITIETDONHANG.maDH)
            {
                return BadRequest();
            }

            db.Entry(cHITIETDONHANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CHITIETDONHANGExists(id))
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

        // POST: api/CHITIETDONHANGs
        [ResponseType(typeof(CHITIETDONHANG))]
        public IHttpActionResult PostCHITIETDONHANG(CHITIETDONHANG cHITIETDONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CHITIETDONHANGs.Add(cHITIETDONHANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CHITIETDONHANGExists(cHITIETDONHANG.maDH))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cHITIETDONHANG.maDH }, cHITIETDONHANG);
        }

        // DELETE: api/CHITIETDONHANGs/5
        [ResponseType(typeof(CHITIETDONHANG))]
        public IHttpActionResult DeleteCHITIETDONHANG(string id)
        {
            CHITIETDONHANG cHITIETDONHANG = db.CHITIETDONHANGs.Find(id);
            if (cHITIETDONHANG == null)
            {
                return NotFound();
            }

            db.CHITIETDONHANGs.Remove(cHITIETDONHANG);
            db.SaveChanges();

            return Ok(cHITIETDONHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CHITIETDONHANGExists(string id)
        {
            return db.CHITIETDONHANGs.Count(e => e.maDH == id) > 0;
        }
    }
}