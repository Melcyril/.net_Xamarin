using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Forum_xamarinApi.Models;

namespace Forum_xamarinApi.Controllers
{
    public class ForumsController : ApiController
    {
        private MasterCodeEntities db = new MasterCodeEntities();

        // GET: api/Forums
        public IQueryable<Forum> GetForum()
        {
            return db.Forum;
        }

        // GET: api/Forums/5
        [ResponseType(typeof(Forum))]
        public async Task<IHttpActionResult> GetForum(int id)
        {
            Forum forum = await db.Forum.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }

            return Ok(forum);
        }

        // PUT: api/Forums/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutForum(int id, Forum forum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forum.IdForum)
            {
                return BadRequest();
            }

            db.Entry(forum).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(id))
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

        // POST: api/Forums
        [ResponseType(typeof(Forum))]
        public async Task<IHttpActionResult> PostForum(Forum forum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Forum.Add(forum);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = forum.IdForum }, forum);
        }

        // DELETE: api/Forums/5
        [ResponseType(typeof(Forum))]
        public async Task<IHttpActionResult> DeleteForum(int id)
        {
            Forum forum = await db.Forum.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }

            db.Forum.Remove(forum);
            await db.SaveChangesAsync();

            return Ok(forum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ForumExists(int id)
        {
            return db.Forum.Count(e => e.IdForum == id) > 0;
        }
    }
}