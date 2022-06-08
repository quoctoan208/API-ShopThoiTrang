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
    public class NGUOIDUNGsController : ApiController
    {
        private Doan4_SHOPEntities1 db = new Doan4_SHOPEntities1();

        // GET: api/NGUOIDUNGs
        public IQueryable<NGUOIDUNG> GetNGUOIDUNGs()
        {
            return db.NGUOIDUNGs;
        }

        // GET: api/NGUOIDUNGs/5
        [ResponseType(typeof(NGUOIDUNG))]
        public IHttpActionResult GetNGUOIDUNG(string id)
        {
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return NotFound();
            }

            return Ok(nGUOIDUNG);
        }

        // PUT: api/NGUOIDUNGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNGUOIDUNG(string id, NGUOIDUNG nGUOIDUNG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nGUOIDUNG.Id)
            {
                return BadRequest();
            }

            db.Entry(nGUOIDUNG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NGUOIDUNGExists(id))
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

        // POST: api/NGUOIDUNGs
        [ResponseType(typeof(NGUOIDUNG))]
        public IHttpActionResult PostNGUOIDUNG(NGUOIDUNG nGUOIDUNG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NGUOIDUNGs.Add(nGUOIDUNG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NGUOIDUNGExists(nGUOIDUNG.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nGUOIDUNG.Id }, nGUOIDUNG);
        }

        // DELETE: api/NGUOIDUNGs/5
        [ResponseType(typeof(NGUOIDUNG))]
        public IHttpActionResult DeleteNGUOIDUNG(string id)
        {
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return NotFound();
            }

            db.NGUOIDUNGs.Remove(nGUOIDUNG);
            db.SaveChanges();

            return Ok(nGUOIDUNG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NGUOIDUNGExists(string id)
        {
            return db.NGUOIDUNGs.Count(e => e.Id == id) > 0;
        }
    }
}