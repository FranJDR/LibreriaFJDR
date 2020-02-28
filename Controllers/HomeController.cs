using LibreriaFJDR.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibreriaFJDR.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Carrito()
        {
            if (User.Identity.IsAuthenticated)
            {

                System.Diagnostics.Debug.WriteLine("ISUARIO => " + User.Identity.Name);
            }
            return View();
        }

        public ActionResult ImprimeFactura(string direccion, string user, string email)
        {
            Factura factura = new Factura(user);
            factura.Email = email;
            factura.Direccion = direccion;
            ViewBag.factura = factura;
            new LogicaCarrito().VaciarCarrito(user);
            return View();
        }

        public ActionResult Print(string direccion)
        {

            return new ActionAsPdf("ImprimeFactura", new
            {
                direccion = direccion,
                user = User.Identity.GetUserId(),
                email = User.Identity.Name
            })
            { FileName = "factura.pdf" };
        }


        public ActionResult AgregarCarrito(string isbn)
        {
            if (User.Identity.IsAuthenticated)
            {
                string idUser = User.Identity.GetUserId();
                new LogicaCarrito().AgregarProducto(idUser, isbn);
            }
            return View("Index");
        }

    }
}