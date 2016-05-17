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
using AseguradoraREST.Models;
using AseguradoraREST.Service.DB;

namespace AseguradoraREST.Controllers
{
    public class PoliciesAPIController : ApiController
    {
        private AseguradoraRESTContext db = new AseguradoraRESTContext();

        // GET: api/PoliciesAPI
        public IQueryable<Policy> GetPolicies()
        {
            return db.Policies;
        }

        // GET: api/PoliciesAPI/5
        [ResponseType(typeof(Policy))]
        public async Task<IHttpActionResult> GetPolicy(int id)
        {
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        // PUT: api/PoliciesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPolicy(int id, Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policy.ID)
            {
                return BadRequest();
            }

            db.Entry(policy).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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

        // POST: api/PoliciesAPI
        [ResponseType(typeof(Policy))]
        public async Task<IHttpActionResult> PostPolicy(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Policies.Add(policy);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = policy.ID }, policy);
        }

        // DELETE: api/PoliciesAPI/5
        [ResponseType(typeof(Policy))]
        public async Task<IHttpActionResult> DeletePolicy(int id)
        {
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            db.Policies.Remove(policy);
            await db.SaveChangesAsync();

            return Ok(policy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolicyExists(int id)
        {
            return db.Policies.Count(e => e.ID == id) > 0;
        }
    }
}