using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class DataService : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Formato> Formatos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        public DataService() : base("DefaultConnection")
        {

        }

    }
}