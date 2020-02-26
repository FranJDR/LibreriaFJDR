using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class Carrito
    {
        [Key]
        public Int32 ID { get; set; }
        [Required]
        public string idUsuario { get; set; }
        [Required]
        public string ISBN { get; set; }
        public Int32 Cantidad { get; set; }

        public Carrito(string idUsuario, string iSBN, int cantidad)
        {
            this.idUsuario = idUsuario;
            this.ISBN = iSBN;
            this.Cantidad = cantidad;
        }

        public Carrito()
        {
            this.Cantidad = 0;
        }
    }

}