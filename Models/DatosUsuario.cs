using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class DatosUsuario
    {
        [Key]
        public string IdUser { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}