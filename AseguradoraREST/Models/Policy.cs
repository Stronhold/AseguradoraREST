using System.ComponentModel.DataAnnotations;

namespace AseguradoraREST.Models
{
    public class Policy
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }
}