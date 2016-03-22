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
    public class BillsAsyncController : ApiController
    {
        private AseguradoraRESTContext db = new AseguradoraRESTContext();

        /// <summary>
        /// Gets all the bills
        /// </summary>
        /// <returns>The bills</returns>
        // GET: api/BillsAsync
        public IQueryable<Bill> GetBills()
        {
            return db.Bills;
        }

        /// <summary>
        /// Get a bill
        /// </summary>
        /// <param name="id">ID of the bill to recover</param>
        /// <returns>A bill</returns>
        // GET: api/BillsAsync/5
        [ResponseType(typeof(Bill))]
        public async Task<IHttpActionResult> GetBill(int id)
        {
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        /// <summary>
        /// Updates a bill
        /// </summary>
        /// <param name="id">ID of the bill to update</param>
        /// <param name="bill">The new bill</param>
        /// <returns>An http result</returns>
        // PUT: api/BillsAsync/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBill(int id, Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bill.ID)
            {
                return BadRequest();
            }

            db.Entry(bill).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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
        /// Adds a bill to DB
        /// </summary>
        /// <param name="bill">Bill to add</param>
        /// <returns>An http result</returns>
        // POST: api/BillsAsync
        [ResponseType(typeof(Bill))]
        public async Task<IHttpActionResult> PostBill(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bills.Add(bill);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bill.ID }, bill);
        }

        /// <summary>
        /// Deletes a bill
        /// </summary>
        /// <param name="id">Id of the bill to delete</param>
        /// <returns>An http result</returns>
        // DELETE: api/BillsAsync/5
        [ResponseType(typeof(Bill))]
        public async Task<IHttpActionResult> DeleteBill(int id)
        {
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            db.Bills.Remove(bill);
            await db.SaveChangesAsync();

            return Ok(bill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BillExists(int id)
        {
            return db.Bills.Count(e => e.ID == id) > 0;
        }
    }
}