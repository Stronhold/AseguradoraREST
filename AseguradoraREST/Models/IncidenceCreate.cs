using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AseguradoraREST.Models.Validation;

namespace AseguradoraREST.Models
{
    public class IncidenceCreate
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public  string dni { get; set; }
    }
}
