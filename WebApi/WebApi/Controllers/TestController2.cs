using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Model;
using WebApi.Model.Model.Test;

namespace WebApi.Controllers
{
    public class Test2Controller : ApiController
    {
        private WebApiDbContext db = new WebApiDbContext();

        // GET: api/TestController2
        public IQueryable<Test> GetTest()
        {
            return db.Test;
        }

        // GET: api/TestController2/5
        [HttpGet]
        public String GetTesthehe(int id)
        {
            string hahaha = "hahhahaha";
            if (id == 0) hahaha = "no fajnie";
            Thread.Sleep(10000);
            return hahaha;
        }

        // PUT: api/TestController2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTest(int id, Test test)
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
                db.SaveChanges();
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

        // POST: api/TestController2
        [ResponseType(typeof(Test))]
        public IHttpActionResult PostTest(Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Test.Add(test);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = test.Id }, test);
        }

        // DELETE: api/TestController2/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult DeleteTest(int id)
        {
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            db.Test.Remove(test);
            db.SaveChanges();

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