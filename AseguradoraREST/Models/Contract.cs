using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraREST.Models
{
    public class Contract
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public virtual Client client { get; set; }
        public virtual Policy policy { get; set; }
    }
}
