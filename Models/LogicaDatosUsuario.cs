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

        public void ModifcarDNI(string id, string dni)
        {
            using (DataService db = new DataService())
            {
                DatosUsuario user = db.DatosUsuarios.Find(id);
                user.DNI = dni;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ModifcarNombre(string id, string nombre)
        {
            using (DataService db = new DataService())
            {
                DatosUsuario user = db.DatosUsuarios.Find(id);
                user.Nombre = nombre;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ModifcarApellidos(string id, string apellidos)
        {
            using (DataService db = new DataService())
            {
                DatosUsuario user = db.DatosUsuarios.Find(id);
                user.Apellidos = apellidos;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ModifcarTelefono(string id, string telefono)
        {
            using (DataService db = new DataService())
            {
                DatosUsuario user = db.DatosUsuarios.Find(id);
                user.Telefono = telefono;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ModifcarDireccion(string id, string direccion)
        {
            using (DataService db = new DataService())
            {
                DatosUsuario user = db.DatosUsuarios.Find(id);
                user.Direccion = direccion;
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