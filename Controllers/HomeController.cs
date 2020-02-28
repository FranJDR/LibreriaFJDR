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

        public ActionResult ImprimeFactura(
            string direccion,
            string user,
            string email,
            string nombre,
            string formaPago)
        {
            Factura factura = new Factura(user)
            {
                Email = email,
                Direccion = direccion,
                Nombre = nombre,
                FormaPago = formaPago
            };
            ViewBag.factura = factura;
            new LogicaCarrito().VaciarCarrito(user);
            return View();
        }

        public ActionResult Print(string direccion, string nombre, string formaPago)
        {

            return new ActionAsPdf("ImprimeFactura", new
            {
                direccion = direccion,
                user = User.Identity.GetUserId(),
                email = User.Identity.Name,
                nombre = nombre,
                formaPago = formaPago
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
            return RedirectToAction("Index", "Home");
        }

    }
}