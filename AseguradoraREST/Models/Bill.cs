using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraREST.Models
{
    /// <summary>
    /// Represents a bill
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Amount of money that a client must pay
        /// </summary>
        public int moneyToPay { get; set; }
        /// <summary>
        /// Client who has recieved this bill
        /// </summary>
        public virtual Client Client { get; set; }

    }
}
