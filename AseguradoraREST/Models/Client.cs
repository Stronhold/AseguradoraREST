using AseguradoraREST.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraREST.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        [MaxLength(9), MinLength(9), CustomValidation(typeof(DNIValidation), "DNICorrectlyFormed")]
        public string DNI { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }

    }
}
