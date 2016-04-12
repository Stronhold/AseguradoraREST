using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AseguradoraREST.Models;
using AseguradoraREST.Service.DB;

namespace AseguradoraREST.Controllers
{
    /// <summary>
    /// Controller de los clientes
    /// </summary>
    public class ClientsController : ApiController
    {
        private readonly AseguradoraRESTContext _db = new AseguradoraRESTContext();

        /// <summary>
        /// Get all the clients
        /// </summary>
        /// <returns>All the clients</returns>
        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return _db.Clients;
        }

        /// <summary>
        /// Get a client
        /// </summary>
        /// <param name="id">ID of the client to return</param>
        /// <returns>A client</returns>
        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = _db.Clients.Find(id);
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
        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ID)
            {
                return BadRequest();
            }

            _db.Entry(client).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
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
        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Clients.Add(client);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ID }, client);
        }

        /// <summary>
        /// Deletes a client
        /// </summary>
        /// <param name="id">ID of the client</param>
        /// <returns>HTTP result</returns>
        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = _db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            _db.Clients.Remove(client);
            _db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return _db.Clients.Count(e => e.ID == id) > 0;
        }
    }
}