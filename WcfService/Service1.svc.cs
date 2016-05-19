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
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
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
            //e.Set<Policies>().Add(p);
            //e.SaveChanges();
            var s = from abc in e.Policies select abc;
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
    }
}
