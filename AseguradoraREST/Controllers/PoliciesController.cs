using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AseguradoraREST.ServicePolicy;

namespace AseguradoraREST.Controllers
{
    public class PoliciesController : Controller
    {
        // GET: Policies
        public ActionResult Index()
        {
            var s = new ServicePolicy.ServicePolicyClient();
            var pol = s.GetAllPolicies();
            var list = new List<Policy>();
            foreach (var policy in pol)
            {
                list.Add(policy);
            }
            return View(list);
        }
        public  ActionResult Details(int? id)
        {
            return HttpNotFound();
        }

        // GET: Incidences/Create
        public  ActionResult Create()
        {
            //TIENES POR AHÍ POLICIES CONTROLLER?
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] Policy p)
        {
            if (ModelState.IsValid)
            {
                var s = new ServicePolicyClient();
                s.AddPolicy(1, p.Name, p.Description, "");
                return RedirectToAction("Index");
            }
            return View(p);

        }

        public async Task<ActionResult> Edit(int id)
        {
            return HttpNotFound();
        }

        public async Task<ActionResult> Delete()
        {
            return HttpNotFound();
        }


    }
}