using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Model;
using WebApi.Model.Logic;
using WebApi.Model.Model.Test;

namespace WebApi.Controllers
{
    public class TestController : ApiController
    {
        private WebApiDbContext db = new WebApiDbContext();

        // GET: api/Test
        [HttpGet]
        [ResponseType(typeof(String))]
        public async Task<IHttpActionResult> GetTesthehe(int id)
        {
            var x1 = new Mapping();
            Test test = await db.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // GET: api/Test/5
        [ResponseType(typeof(Test))]
        public async Task<IHttpActionResult> GetTest(int id)
        {
            Test test = await db.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/Test/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTest(int id, Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.Id)
            {
                return BadRequest();
            }

            db.Entry(test).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        // POST: api/Test
        [ResponseType(typeof(Test))]
        public async Task<IHttpActionResult> PostTest(Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Test.Add(test);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = test.Id }, test);
        }

        // DELETE: api/Test/5
        [ResponseType(typeof(Test))]
        public async Task<IHttpActionResult> DeleteTest(int id)
        {
            Test test = await db.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            db.Test.Remove(test);
            await db.SaveChangesAsync();

            return Ok(test);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestExists(int id)
        {
            return db.Test.Count(e => e.Id == id) > 0;
        }
    }
}