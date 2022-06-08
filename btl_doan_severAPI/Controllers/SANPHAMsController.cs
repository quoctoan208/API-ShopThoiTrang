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
    public class SANPHAMsController : ApiController
    {
        private Doan4_SHOPEntities1 db = new Doan4_SHOPEntities1();

        // GET: api/SANPHAMs
        public IQueryable<SANPHAM> GetSANPHAMs()
        {
            return db.SANPHAMs;
        }

        // GET: api/SANPHAMs/5
        [ResponseType(typeof(SANPHAM))]
        public IHttpActionResult GetSANPHAM(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            return Ok(sANPHAM);
        }

        // PUT: api/SANPHAMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSANPHAM(string id, SANPHAM sANPHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sANPHAM.maSP)
            {
                return BadRequest();
            }

            db.Entry(sANPHAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SANPHAMExists(id))
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

        // POST: api/SANPHAMs
        [ResponseType(typeof(SANPHAM))]
        public IHttpActionResult PostSANPHAM(SANPHAM sANPHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SANPHAMs.Add(sANPHAM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SANPHAMExists(sANPHAM.maSP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sANPHAM.maSP }, sANPHAM);
        }

        // DELETE: api/SANPHAMs/5
        [ResponseType(typeof(SANPHAM))]
        public IHttpActionResult DeleteSANPHAM(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            db.SANPHAMs.Remove(sANPHAM);
            db.SaveChanges();

            return Ok(sANPHAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SANPHAMExists(string id)
        {
            return db.SANPHAMs.Count(e => e.maSP == id) > 0;
        }
    }
}