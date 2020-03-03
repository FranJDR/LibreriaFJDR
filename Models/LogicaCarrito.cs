using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LibreriaFJDR.Models;

namespace LibreriaFJDR.Models
{
    public class LogicaCarrito
    {

        public void AgregarProducto(string idUser, string isbn)
        {
            Carrito carrito = this.ObtenerCarrito(idUser, isbn);
            using (DataService db = new DataService())
            {
                if (carrito == null)
                {
                    carrito = new Carrito(idUser, isbn, 1);
                    db.Carritos.Add(carrito);
                }
                else
                {
                    carrito.Cantidad++;
                    db.Entry(carrito).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public void ReducirCantidad(string idUser, string ISBN)
        {
            Carrito carrito = this.ObtenerCarrito(idUser, ISBN);
            using (DataService db = new DataService())
            {
                if (carrito.Cantidad != 1)
                {
                    carrito.Cantidad--;
                    db.Entry(carrito).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public int ObtenerCantidad(string idUser, string isbn)
        {
            return this.ObtenerCarrito(idUser, isbn).Cantidad;
        }

        public List<Libro> ObtenerProductos(string iduser)
        {
            return new LogicaLibro().ObtenerLibrosISBN(this.ObtenerISBNs(iduser));
        }

        public void VaciarCarrito(string idUser)
        {
            using (DataService db = new DataService())
            {
                List<Carrito> carritos = this.ObtenerCarritos(idUser).ToList();
                foreach (Carrito carrito in carritos)
                {
                    db.Entry(carrito).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public void EliminarProducto(string idUser, string isbn)
        {
            Carrito aux = this.ObtenerCarrito(idUser, isbn);
            if (aux != null)
            {
                using (DataService db = new DataService())
                {
                    int idCarrito = aux.ID;
                    Carrito carrito = db.Carritos.Find(idCarrito);
                    db.Carritos.Remove(carrito);
                    db.SaveChanges();
                }
            }
        }

        private List<string> ObtenerISBNs(string idUser)
        {
            List<string> ISBNs = new List<string>();
            foreach (Carrito carrito in this.ObtenerCarritos(idUser))
            {
                ISBNs.Add(carrito.ISBN);
            }
            return ISBNs;
        }

        private Carrito ObtenerCarrito(string idUser, string isbn)
        {
            using (DataService db = new DataService())
            {
                Carrito collection =
                    db.Carritos.Where(a => a.idUsuario == idUser).Where(a => a.ISBN == isbn).FirstOrDefault();
                return collection;
            }
        }

        private List<Carrito> ObtenerCarritos(string idUser)
        {
            using (DataService db = new DataService())
            {
                List<Carrito> collection = db.Carritos.Where(o => o.idUsuario == idUser).ToList();
                return collection;
            }
        }

    }
}