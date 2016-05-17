using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Aseguradora.Services.Classes;

namespace Aseguradora
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicePolicy : IServicePolicy
    {

        public bool AddPolicy(int id, string name, string desc, string type)
        {
            var e = new Entities();
            //Policy policy = new Policy(name, desc, id, type);

            e.Policies.AddOrUpdate(new Policies(id, name, desc, type));
            return true;
        }

        public int[] GetAllID()
        {
            var entities = new Entities();
            var ids = from e in entities.Policies select e.ID;
            return ids.ToArray();
        }

        public Policy[] GetAllPolicies()
        {
            var entities = new Entities();
            var id = from e in entities.Policies select e;
            List<Policy> list = new List<Policy>();
            foreach (var i in id)
            {
                Policy p = new Policy(i.name, i.description, i.ID, i.type);
                list.Add(p);
            }
            return list.ToArray();
        }

        public Policy GetData(int id)
        {
            var entities = new Entities();
            var policies = from e in entities.Policies where e.ID == id select e ;
            var p = policies.ToArray()[0];
            return  new Policy(p.name, p.description, p.ID, p.type);
        }

        public bool RemovePolicy(int id)
        {
            var entities = new Entities();
            var p = from e in entities.Policies where e.ID == id select e;
            if (p.ToList().First() == null) return false;
            entities.Policies.Remove(p.ToList().FirstOrDefault());
            return true;
        }

        public bool UpdatePolicy(int id, string name, string desc, string type)
        {
            var entities = new Entities();
            entities.Policies.AddOrUpdate(new Policies(id, name, desc, type));
            return true;
        }
    }
}
