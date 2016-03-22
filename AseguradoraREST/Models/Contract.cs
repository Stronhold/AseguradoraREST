using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraREST.Models
{
    /// <summary>
    /// Contracts
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Date when it was signed
        /// </summary>
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Client who has signed it
        /// </summary>
        public virtual Client client { get; set; }
        /// <summary>
        /// Type of policy
        /// </summary>
        public virtual Policy policy { get; set; }
    }
}
