using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibreriaFJDR.Models
{
    public class LogicaEstado
    {
        public void AgregarEstado(string newEstado)
        {
            using (var db = new DataService())
            {
                if (!this.IsContains(newEstado))
                {
                    Estado estado = new Estado();
                    estado.Nombre = newEstado;
                    estado.Id = this.ObtenerID();
                    db.Estados.Add(estado);
                    db.SaveChanges();
                }
            }
        }

        public List<SelectListItem> ObtenerSelectList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            foreach (Estado estado in this.ObtenerEstados())
                retorno.Add(new SelectListItem() { Text = estado.Nombre });
           return retorno;
        }

        public List<string> ObtenerListNombres()
        {
            List<string> nombres = new List<string>();
            foreach (Estado estado in this.ObtenerEstados())
                nombres.Add(estado.Nombre);
            return nombres;
        }

        public Estado ObtenerEstado(string id)
        {
            using (var db = new DataService())
            {
                return db.Estados.Find(id);
            }
        }

        public List<Estado> ObtenerEstados()
        {
            using (var db = new DataService())
            {
                return db.Estados.ToList();
            }
        }

        public void EliminarEstado(string id)
        {
            using (var db = new DataService())
            {
                if (!this.EnUso(id))
                {
                    db.Estados.Remove(db.Estados.Find(id));
                    db.SaveChanges();
                }
            }
        }

        private bool EnUso(string id)
        {
            List<Libro> libros = new LogicaLibro().ObtenerLibros();
            foreach (Libro libro in libros)
            {
                if (libro.Estado == this.ObtenerEstado(id).Nombre)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsContains(string nombre)
        {
            foreach (Estado estado in this.ObtenerEstados())
                if (nombre == estado.Nombre)
                    return true;
            return false;
        }

        private string ObtenerID()
        {
            int index = 0;
            List<int> ids = this.ObtenerListIDs();
            while (ids.Contains(index))
                index++;
            return index.ToString();
        }

        private List<int> ObtenerListIDs()
        {
            List<int> retorno = new List<int>();
            foreach (Estado estado in this.ObtenerEstados())
            {
                retorno.Add(int.Parse(estado.Id));
            }
            return retorno;
        }
    }
}