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
    public class ClientsAsyncController : ApiController
    {
        private AseguradoraRESTContext db = new AseguradoraRESTContext();

        /// <summary>
        /// Get all the clients
        /// </summary>
        /// <returns>All the clients</returns>
        // GET: api/ClientsAsync
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        /// <summary>
        /// Get a client
        /// </summary>
        /// <param name="id">ID of the client to return</param>
        /// <returns>A client</returns>
        // GET: api/ClientsAsync/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="id">ID of the client</param>
        /// <param name="client">Client updated</param>
        /// <returns></returns>
        // PUT: api/ClientsAsync/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ID)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        /// <summary>
        /// Adds a client to DB
        /// </summary>
        /// <param name="client">Client to add</param>
        /// <returns>HTTP result</returns>
        // POST: api/ClientsAsync
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = client.ID }, client);
        }

        /// <summary>
        /// Deletes a client
        /// </summary>
        /// <param name="id">ID of the client</param>
        /// <returns>HTTP result</returns>
        // DELETE: api/ClientsAsync/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            await db.SaveChangesAsync();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ID == id) > 0;
        }
    }
}