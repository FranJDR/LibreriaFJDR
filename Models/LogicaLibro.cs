using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class LogicaLibro
    {

        public void ReducirStock(Dictionary<string, int> ISBNCantidad)
        {
            using (DataService db = new DataService())
            {
                foreach (KeyValuePair<string, int> item in ISBNCantidad)
                {
                    Libro libro = this.ObtenerLibro(item.Key);
                    libro.Unidades -= item.Value;
                    db.Entry(libro).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }

        public bool ValidarStock(Dictionary<string, int> ISBNCantidad)
        {
            using (DataService db = new DataService())
            {
                foreach (KeyValuePair<string, int> item in ISBNCantidad)
                {
                    Libro libro = this.ObtenerLibro(item.Key);
                    if (libro.Unidades < item.Value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<Libro> ObtenerLibrosISBN(List<string> listISBN)
        {
            using (DataService db = new DataService())
            {
                return db.Libros.Where(o => listISBN.Contains(o.ISBN)).ToList();
            }
        }

        public List<Libro> ObtenerLibros()
        {
            using (DataService db = new DataService())
            {
                return db.Libros.ToList();
            }
        }

        public List<Libro> ObtenerLibrosISBN(string isbn)
        {
            using (DataService db = new DataService())
            {
                return db.Libros.Where(a => a.ISBN == isbn).ToList();
            }
        }

        public Libro ObtenerLibro(string isbn)
        {
            using (DataService db = new DataService())
            {
                return db.Libros.Find(isbn);
            }
        }

        public int ObtenerCantidad(string isbn)
        {
            using (DataService db = new DataService())
            {
                return db.Libros.Find(isbn).Unidades;
            }
        }

        public void AgregarLibro(Libro libro)
        {
            using (DataService db = new DataService())
            {
                //libro.ISBN = this.GenerarISBN();
                if (!this.IsRepetido(libro.ISBN))
                {
                    db.Libros.Add(libro);
                    db.SaveChanges();
                }
            }
        }

        public void EliminarLibro(string isbn)
        {
            using (var db = new DataService())
            {
                Libro libro = db.Libros.Find(isbn);
                db.Libros.Remove(libro);
                db.SaveChanges();
            }
        }

        public void EditarLibro(Libro libro)
        {
            using (DataService db = new DataService())
            {
                Libro aux = db.Libros.Find(libro.ISBN);
                aux.Precio = libro.Precio;
                aux.Unidades = libro.Unidades;
                db.Entry(aux).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private string GenerarISBN()
        {
            string isbn = "";
            Random rd = new Random();
            do
            {
                isbn = "";
                for (int i = 0; i < 13; i++)
                {
                    isbn += rd.Next(9);
                }
            } while (this.IsRepetido(isbn));
            return isbn;
        }

        private bool IsRepetido(string isbn)
        {
            List<Libro> libros = this.ObtenerLibros();
            foreach (Libro libro in libros)
            {
                if (libro.ISBN == isbn)
                {
                    return true;
                }
            }
            return false;
        }
    }
}