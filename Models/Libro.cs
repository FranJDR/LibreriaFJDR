using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class Libro
    {
        [Key, Required, StringLength(13)]
        public string ISBN { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Formato { get; set; }
        [Required]
        public int Paginas { get; set; }
        [Required]
        public string Unidades { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public string IMG { get; set; }
        [Required]
        public string Sinopsis { get; set; }
    }
}