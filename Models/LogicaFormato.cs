using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibreriaFJDR.Models
{
    public class LogicaFormato
    {
        public List<SelectListItem> ObtenerSelectList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            foreach (Formato formato in this.ObtenerFormatos())
                retorno.Add(new SelectListItem() { Text = formato.Nombre });
            return retorno;
        }

        public List<Formato> ObtenerFormatos()
        {
            using (var db = new DataService())
            {
                return db.Formatos.ToList();
            }
        }

        public Formato ObtenerFormato(string id)
        {
            using (var db = new DataService())
            {
                return db.Formatos.Find(id);
            }
        }

        public void AgregarFormato(string newTema)
        {
            using (var db = new DataService())
            {
                if (!this.IsContains(newTema))
                {
                    Formato formato = new Formato();
                    formato.Id = this.ObtenerID();
                    formato.Nombre = newTema;
                    db.Formatos.Add(formato);
                    db.SaveChanges();
                }
            }
        }

        public void EliminarFormato(string id)
        {
            using (var db = new DataService())
            {
                if (!this.EnUso(id))
                {
                    db.Formatos.Remove(db.Formatos.Find(id));
                    db.SaveChanges();
                }
            }
        }

        private bool EnUso(string id)
        {
            List<Libro> libros = new LogicaLibro().ObtenerLibros();
            foreach (Libro libro in libros)
            {
                if (libro.Formato == this.ObtenerFormato(id).Nombre)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsContains(string nombre)
        {
            foreach (Formato formato in this.ObtenerFormatos())
                if (nombre == formato.Nombre)
                    return true;
            return false;
        }

        private string ObtenerID()
        {
            int index = 0;
            List<int> ids = this.ObtenerIDs();
            while (ids.Contains(index))
                index++;
            return index.ToString();
        }

        private List<int> ObtenerIDs()
        {
            List<int> retorno = new List<int>();
            foreach (Formato formato in this.ObtenerFormatos())
                retorno.Add(int.Parse(formato.Id));
            return retorno;
        }
    }
}