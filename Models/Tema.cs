using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class Tema
    {
        [Key, Required]
        public string id { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}