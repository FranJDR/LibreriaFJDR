using LibreriaFJDR.Models;
using Microsoft.AspNet.Identity;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibreriaFJDR.Controllers
{
    public class CarritoController : Controller
    {

        private LogicaCarrito LogicaCarrito = new LogicaCarrito();

        public ActionResult SumarCantidad(string isbn)
        {
            if (User.Identity.IsAuthenticated)
            {
                string idUser = User.Identity.GetUserId();
                this.LogicaCarrito.AgregarProducto(idUser, isbn);
            }
            return RedirectToAction("Carrito", "Home");
        }

        public ActionResult RestarCantidad(string isbn)
        {
            if (User.Identity.IsAuthenticated)
            {
                string idUser = User.Identity.GetUserId();
                this.LogicaCarrito.ReducirCantidad(idUser, isbn);
            }
            return RedirectToAction("Carrito", "Home");
        }

        public ActionResult QuitarProducto(string isbn)
        {
            if (User.Identity.IsAuthenticated)
            {
                string idUser = User.Identity.GetUserId();
                this.LogicaCarrito.EliminarProducto(idUser, isbn);
            }
            return RedirectToAction("Carrito", "Home");
        }

    }
}