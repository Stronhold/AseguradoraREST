﻿using System;
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
    public class ContractsController : ApiController
    {
        private AseguradoraRESTContext db = new AseguradoraRESTContext();

        /// <summary>
        /// Returns all the contracts 
        /// </summary>
        /// <returns>All the contracts</returns>
        // GET: api/Contracts
        public IQueryable<Contract> GetContracts()
        {
            return db.Contracts;
        }

        /// <summary>
        /// Get a contract
        /// </summary>
        /// <param name="id">ID of the contract</param>
        /// <returns>An http result</returns>
        // GET: api/Contracts/5
        [ResponseType(typeof(Contract))]
        public IHttpActionResult GetContract(int id)
        {
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        /// <summary>
        /// Updates a contract
        /// </summary>
        /// <param name="id">ID of the contract</param>
        /// <param name="contract">Contract updated</param>
        /// <returns>An http result</returns>
        // PUT: api/Contracts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContract(int id, Contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contract.ID)
            {
                return BadRequest();
            }

            db.Entry(contract).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
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
        /// Adds a Contract 
        /// </summary>
        /// <param name="contract">The contract</param>
        /// <returns>An http result</returns>
        // POST: api/Contracts
        [ResponseType(typeof(Contract))]
        public IHttpActionResult PostContract(Contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contracts.Add(contract);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contract.ID }, contract);
        }

        /// <summary>
        /// Removes a a contact
        /// </summary>
        /// <param name="contract">The contract</param>
        /// <returns>An http result</returns>
        // DELETE: api/ContractsAsync/5
        // DELETE: api/Contracts/5
        [ResponseType(typeof(Contract))]
        public IHttpActionResult DeleteContract(int id)
        {
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return NotFound();
            }

            db.Contracts.Remove(contract);
            db.SaveChanges();

            return Ok(contract);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContractExists(int id)
        {
            return db.Contracts.Count(e => e.ID == id) > 0;
        }
    }
}