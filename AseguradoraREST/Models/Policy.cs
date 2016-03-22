using System.ComponentModel.DataAnnotations;

namespace AseguradoraREST.Models
{
    /// <summary>
    /// Policy
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Name of the policy
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Description of the policy
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Type of policy
        /// </summary>
        public string type { get; set; }
    }
}