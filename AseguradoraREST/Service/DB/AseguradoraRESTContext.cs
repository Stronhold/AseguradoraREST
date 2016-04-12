using AseguradoraREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AseguradoraREST.Service.DB
{
    public class AseguradoraRESTContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AseguradoraRESTContext() : base("name=AseguradoraRESTContext")
        {
        }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Policy> Policies { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public System.Data.Entity.DbSet<AseguradoraREST.Models.Incidence> Incidences { get; set; }
    }
}
