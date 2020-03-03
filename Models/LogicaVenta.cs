using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class LogicaVenta
    {
        public List<Venta> ObtenerVentas()
        {
            using (DataService db = new DataService())
            {
                return db.Ventas.ToList();
            }
        }

        public void AgregarVenta(Venta venta)
        {
            using (DataService db = new DataService())
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
            }
        }

    }
}