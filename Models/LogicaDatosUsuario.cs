using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibreriaFJDR.Models
{
    public class LogicaDatosUsuario
    {

        public void CrearDatosUsuario(DatosUsuario datos)
        {
            using (DataService db = new DataService())
            {
                db.DatosUsuarios.Add(datos);
                db.SaveChanges();
            }
        }

        public void MidficarDatos(DatosUsuario newDatos)
        {
            using (DataService db = new DataService())
            {
                DatosUsuario user = db.DatosUsuarios.Find(newDatos.IdUser);
                user = newDatos;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool ExistenDatos(string IdUser)
        {
            using (DataService db = new DataService())
            {
                return db.DatosUsuarios.Find(IdUser) != null;
            }
        }

        public DatosUsuario ObtenerDatos(string IdUser)
        {
            using (DataService db = new DataService())
            {
                return db.DatosUsuarios.Find(IdUser);
            }
        }

    }
}