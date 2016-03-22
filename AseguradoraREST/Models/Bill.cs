using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraREST.Models
{
    public class Bill
    {
        [Key]
        public int ID { get; set; }
        public int moneyToPay { get; set; }
        public virtual Client Client { get; set; }

    }
}
