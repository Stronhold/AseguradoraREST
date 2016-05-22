using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private Entities e;

        public void Init()
        {
            if (e == null)
            {
                e = new Entities();
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void AddPolicie(int i, string n, string d, string y)
        {
            Init();
            var p = new Policies(i, n, d, y);
            /*How to add*/
            //e.Set<Policies>().Add(p);9
            //e.SaveChanges();
            var s = from abc in e.Policies where abc.ID > 0 select abc;
            var policy = e.Policies.Find(1);
            //e.Policies.Find(1);
            //   var asd = s.;
            /*How to update*/
            //e.Policies.Attach(p);
            //p.description = "smth";

            /*How to remove*/
            //e.Policies.Attach(p);
            //e.Set<Policies>().Remove(p);
            //e.SaveChanges();
            e.SaveChanges();

        }

        public bool AddPolicy(int id, string name, string desc, string type)
        {
            Init();
            var policy = new Policies(id, name, desc, type);
            var pol = e.Policies.Select(p => p.ID == id).Where(r => r == true);
            if (pol.Any()) return false;
            e.Policies.Add(policy);
            e.SaveChanges();
            return true;
        }

        public int[] GetAllID()
        { 
        Init();
            var ids = from p in e.Policies select p.ID;

            return ids.ToArray();
        }

        public Policies[] GetAllPolicies()
        {
            Init();
            var policies = from p in e.Policies select p;
            return policies.ToArray();
        }

        public Policies GetData(int id)
        {
            Init();
            var policies = e.Policies.Find(id);
            return policies;
        }

        public bool RemovePolicy(int id)
        {
            Init();
            var policy = e.Policies.Find(id);
            if (policy != null)
            {
                e.Policies.Remove(policy);
                e.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdatePolicy(int id, string name, string desc, string type)
        {
            Init();
            var policy = e.Policies.Find(id);
            if (policy != null)
            {
                e.Entry(policy).State = EntityState.Modified;
                policy.name = name;
                policy.description = desc;
                policy.type = type;
                e.SaveChanges();
            }
            return false;
        }
    }


}
