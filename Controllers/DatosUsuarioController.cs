using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LibreriaFJDR.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibreriaFJDR.Controllers
{
    public class DatosUsuarioController : Controller
    {

        public ActionResult ModificarDNI(string dni)
        {
            new LogicaDatosUsuario().ModifcarDNI(User.Identity.GetUserId(), dni);
            return RedirectToAction("MiCuenta", "Home");
        }

        public ActionResult ModificarNombre(string nombre)
        {
            new LogicaDatosUsuario().ModifcarNombre(User.Identity.GetUserId(), nombre);
            return RedirectToAction("MiCuenta", "Home");
        }

        public ActionResult ModificarApellidos(string apellidos)
        {
            new LogicaDatosUsuario().ModifcarApellidos(User.Identity.GetUserId(), apellidos);
            return RedirectToAction("MiCuenta", "Home");
        }

        public ActionResult ModificarTelefono(string telefono)
        {
            new LogicaDatosUsuario().ModifcarTelefono(User.Identity.GetUserId(), telefono);
            return RedirectToAction("MiCuenta", "Home");
        }
        public ActionResult ModificarDireccion(string direccion)
        {
            new LogicaDatosUsuario().ModifcarDireccion(User.Identity.GetUserId(), direccion);
            return RedirectToAction("MiCuenta", "Home");
        }
    }
}