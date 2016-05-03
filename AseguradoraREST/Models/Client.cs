using AseguradoraREST.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AseguradoraREST.Models
{
    /// <summary>
    /// Represents a client
    /// </summary>
    public class Client
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Name of the client
        /// </summary>
        [Display(Name = "Client's name")]
        public string name { get; set; }
        /// <summary>
        /// DNI of the client
        /// </summary>
        [MaxLength(9), MinLength(9), CustomValidation(typeof(DNIValidation), "DNICorrectlyFormed")]
        public string DNI { get; set; }
        /// <summary>
        /// List of bills that a client has recieved
        /// </summary>
        public virtual ICollection<Bill> Bills { get; set; }
        /// <summary>
        /// List of contracts that a client has signed
        /// </summary>
        public virtual ICollection<Contract> Contracts { get; set; }

        /// <summary>
        /// List of incidences that a client has registered
        /// </summary>
        public virtual ICollection<Incidence> Incidences { get; set; } 

    }
}
