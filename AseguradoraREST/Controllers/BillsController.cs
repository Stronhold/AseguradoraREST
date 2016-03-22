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
using AseguradoraREST.Models;
using AseguradoraREST.Service.DB;

namespace AseguradoraREST.Controllers
{
    public class BillsController : ApiController
    {
        private AseguradoraRESTContext db = new AseguradoraRESTContext();

        // GET: api/Bills
        public IQueryable<Bill> GetBills()
        {
            return db.Bills;
        }

        // GET: api/Bills/5
        [ResponseType(typeof(Bill))]
        public IHttpActionResult GetBill(int id)
        {
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // PUT: api/Bills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBill(int id, Bill bill)
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
                db.SaveChanges();
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

        // POST: api/Bills
        [ResponseType(typeof(Bill))]
        public IHttpActionResult PostBill(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bills.Add(bill);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bill.ID }, bill);
        }

        // DELETE: api/Bills/5
        [ResponseType(typeof(Bill))]
        public IHttpActionResult DeleteBill(int id)
        {
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return NotFound();
            }

            db.Bills.Remove(bill);
            db.SaveChanges();

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