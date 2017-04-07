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
using GameWeb.Models;
using GameWeb;

namespace GameWeb.Controllers
{
    public class MarkController : ApiController
    {
        private GameWebDbContext db = new GameWebDbContext();

        // GET api/Mark
        public IQueryable<Mark> GetMarks()
        {
            return db.Marks;
        }

        // GET api/Mark/5
        [ResponseType(typeof(Mark))]
        public IHttpActionResult GetMark(int id)
        {
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

        // PUT api/Mark/5
        public IHttpActionResult PutMark(int id, Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mark.Id)
            {
                return BadRequest();
            }

            db.Entry(mark).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkExists(id))
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

        // POST api/Mark
        [ResponseType(typeof(Mark))]
        public IHttpActionResult PostMark(Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marks.Add(mark);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mark.Id }, mark);
        }

        // DELETE api/Mark/5
        [ResponseType(typeof(Mark))]
        public IHttpActionResult DeleteMark(int id)
        {
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return NotFound();
            }

            db.Marks.Remove(mark);
            db.SaveChanges();

            return Ok(mark);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarkExists(int id)
        {
            return db.Marks.Count(e => e.Id == id) > 0;
        }
    }
}