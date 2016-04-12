using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AseguradoraREST.Models
{
    public class Incidence
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public virtual Client client { get; set; }

        public Incidence()
        {
            Id = 0;
            name = "";
            description = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <param name="c"></param>
        public Incidence(int i, string n, string d, Client c)
        {
            Id = i;
            name = n;
            description = d;
            client = c;
        }
    }
}