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

        public ActionResult Index(string isbn)
        {
            List<Libro> libros = new List<Libro>();
            if (string.IsNullOrEmpty(isbn))
            {
                libros = new LogicaLibro().ObtenerLibros();
            }
            else
            {
                libros = new LogicaLibro().ObtenerLibrosISBN(isbn);
            }
            ViewBag.libros = libros;
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
            string formaPago,
            string dni)
        {
            Factura factura = new Factura(user)
            {
                Email = email,
                Direccion = direccion,
                Nombre = nombre,
                FormaPago = formaPago,
                DNI = dni
            };

            Venta venta = new Venta()
            {
                Direccion = direccion,
                Nombre = nombre,
                Email = email,
                PrecioTotal = factura.PrecioTotal,
                Fecha = DateTime.Now,
                FormaPago = formaPago,
                DNI = dni
            };

            ViewBag.factura = factura;
            new LogicaVenta().AgregarVenta(venta);
            new LogicaLibro().ReducirStock(factura.ISBNCantidad);
            new LogicaCarrito().VaciarCarrito(user);
            return View();
        }

        public ActionResult Print(string direccion, string nombre, string formaPago, string dni)
        {

            return new ActionAsPdf("ImprimeFactura", new
            {
                direccion = direccion,
                user = User.Identity.GetUserId(),
                email = User.Identity.Name,
                nombre = nombre,
                formaPago = formaPago,
                dni = dni
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