using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class Compra
    {
        [Key]
        public string id { get; set; }
        [Required]
        public string idUsuario { get; set; }
        public Dictionary<string, Int32> ProductoCantidad { get; set; }
        public string Direccion { get; set; }
        public Int32 PrecioTotal { get; set; }
    }
}