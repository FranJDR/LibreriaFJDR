using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class LogicaLibro
    {
        public List<Libro> ObtenerLibros()
        {
            using (DataService db = new DataService())
            {
                return db.Libros.ToList();
            }
        }

        public Libro ObtenerLibro(string isbn)
        {
            using (DataService db = new DataService())
            {
                return db.Libros.Find(isbn);
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
            this.EliminarLibro(libro.ISBN);
            this.AgregarLibro(libro);
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