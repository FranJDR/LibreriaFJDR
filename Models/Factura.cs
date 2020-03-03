using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibreriaFJDR.Models;

namespace LibreriaFJDR.Models
{
    public class Factura
    {
        public string IdUsuario { get; set; }
        public List<Libro> Libros { get; set; }
        public Dictionary<string, int> ISBNCantidad { get; set; }
        public string Direccion { get; set; }
        public float PrecioTotal { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string CIF { get; set; }
        public string FormaPago { get; set; }
        public DateTime Fecha { get; set; }
        public string DNI { get; set; }


        public Factura(string idUsuario)
        {
            IdUsuario = idUsuario;
            System.Diagnostics.Debug.WriteLine("ID USUARIO dentro de factura : " + this.IdUsuario);
            this.Libros = new LogicaCarrito().ObtenerProductos(this.IdUsuario);
            this.CIF = "1231241423d";
            this.CalcularPrecioTotal();
        }

        private void CalcularPrecioTotal()
        {
            this.ISBNCantidad = new Dictionary<string, int>();
            LogicaCarrito logicaCarrito = new LogicaCarrito();
            foreach (Libro libro in this.Libros)
            {
                int cantidad = logicaCarrito.ObtenerCantidad(this.IdUsuario, libro.ISBN);
                this.PrecioTotal += libro.Precio * cantidad;
                this.ISBNCantidad.Add(libro.ISBN, cantidad);
            }
        }

        public int ObtenerCantidad(string isbn)
        {
            return this.ISBNCantidad[isbn];
        }

    }
}