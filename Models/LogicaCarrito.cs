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
                carrito.Cantidad--;
                db.Entry(carrito).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int ObtenerCantidad(string idUser, string isbn)
        {
            return this.ObtenerCarrito(idUser, isbn).Cantidad;
        }

        public List<Libro> ObtenerProductos(string iduser)
        {
            List<Libro> libros = new LogicaLibro().ObtenerLibros();
            List<string> ISBNs = this.ObtenerISBNs(iduser);
            List<Libro> retorno = new List<Libro>();
            libros.ForEach((libro) =>
            {
                if (ISBNs.Contains(libro.ISBN))
                    retorno.Add(libro);
            });
            return retorno;
        }

        public void VaciarCarrito(string idUser)
        {
            using (DataService db = new DataService())
            {
                foreach (Carrito carrito in this.ObtenerCarritos(idUser).ToList())
                {
                    db.Carritos.Remove(carrito);
                }
                db.SaveChanges();
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
                List<Carrito> listCarrito = db.Carritos.ToList();
                if (listCarrito != null)
                {
                    foreach (Carrito carrito in listCarrito)
                    {
                        if (carrito.idUsuario == idUser && carrito.ISBN == isbn)
                        {
                            return carrito;
                        }
                    }
                }
            }
            return null;
        }

        private List<Carrito> ObtenerCarritos(string idUser)
        {
            List<Carrito> retorno = new List<Carrito>();
            using (DataService db = new DataService())
            {
                foreach (Carrito carrito in db.Carritos.ToList())
                {
                    if (carrito.idUsuario == idUser)
                    {
                        retorno.Add(carrito);
                    }
                }
            }
            return retorno;
        }

        private List<Int32> ObtenerListID()
        {
            List<Int32> retorno = new List<int>();
            using (DataService db = new DataService())
            {
                foreach (Carrito carrito in db.Carritos.ToList())
                {
                    retorno.Add(carrito.ID);
                }
            }
            return retorno;
        }


    }
}