using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class Venta
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public float PrecioTotal { get; set; }
        public string FormaPago { get; set; }
        public string DNI { get; set; }

    }
}