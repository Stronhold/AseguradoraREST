using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using AseguradoraREST.Models;
using AseguradoraREST.Service.DB;

namespace AseguradoraREST.Controllers
{
    public class IncidencesController : Controller
    {
        private AseguradoraRESTContext db = new AseguradoraRESTContext();

        // GET: Incidences
        public async Task<ActionResult> Index()
        {
            return View(await db.Incidences.ToListAsync());
        }

        // GET: Incidences/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidence incidence = await db.Incidences.FindAsync(id);
            if (incidence == null)
            {
                return HttpNotFound();
            }
            return View(incidence);
        }

        // GET: Incidences/Create
        public async Task<ActionResult> Create()
        {
            var clients = await db.Clients.ToListAsync();
            var dnis = clients.Select(c => new SelectListItem()
            {
                Text = c.DNI
            });
            ViewBag.dnis = dnis;
            return View();
        }

        // POST: Incidences/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,name,description")] Incidence incidence, string dnis)
        {
            if (ModelState.IsValid)
            {
                Client client = await db.Clients.Where(b => b.DNI == dnis).FirstOrDefaultAsync();
                if (client != null)
                {
                    db.Entry(client).State = EntityState.Modified;
                    Incidence i = new Incidence(incidence.Id, incidence.name, incidence.description, client);
                    db.Incidences.Add(i);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View(incidence);
        }

        // GET: Incidences/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidence incidence = await db.Incidences.FindAsync(id);
            if (incidence == null)
            {
                return HttpNotFound();
            }
            return View(incidence);
        }

        // POST: Incidences/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,name,description")] Incidence incidence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidence).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(incidence);
        }

        // GET: Incidences/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidence incidence = await db.Incidences.FindAsync(id);
            if (incidence == null)
            {
                return HttpNotFound();
            }
            return View(incidence);
        }

        // POST: Incidences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Incidence incidence = await db.Incidences.FindAsync(id);
            db.Incidences.Remove(incidence);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
