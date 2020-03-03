using LibreriaFJDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibreriaFJDR.Controllers
{
    public class AdminController : Controller
    {
        private LogicaLibro datos = new LogicaLibro();
        private string rutaVistaFormato = "VistaFormato";
        private string rutaVistaEstado = "VistaEstado";


        public ActionResult AgregarLibro(Libro libro, string estado, string formato)
        {
            libro.Estado = estado;
            libro.Formato = formato;
            this.datos.AgregarLibro(libro);
            return RedirectToAction("Admin", "Home");
        }

        public ActionResult EliminarLibro(string isbn)
        {
            this.datos.EliminarLibro(isbn);
            return RedirectToAction("Admin", "Home");
        }

        public ActionResult RedirigirMofificarLibro(string isbn)
        {
            ViewBag.ISBN = isbn;
            return View("ModificarLibro");
        }

        public ActionResult RedirigirAgregarLibro()
        {
            return View("AgregarLibro");
        }

        public ActionResult EditarLibro(string isbn, int precio, int unidades)
        {
            Libro libro = new Libro()
            {
                ISBN = isbn,
                Precio = precio,
                Unidades = unidades
            };
            this.datos.EditarLibro(libro);
            return RedirectToAction("Admin", "Home");
        }

        public ActionResult ComprarLibro(Libro libro)
        {
            return RedirectToAction("Admin", "Home");
        }

        public ActionResult VenderLibro(Libro libro)
        {
            return RedirectToAction("Admin", "Home");
        }
        /*------------------------------ESTADO------------------------------*/
        public ActionResult AgregarEstado(Estado estado)
        {
            new LogicaEstado().AgregarEstado(estado.Nombre);
            return View(this.rutaVistaEstado);
        }

        public ActionResult EliminarEstado(string id)
        {
            new LogicaEstado().EliminarEstado(id);
            return View(this.rutaVistaEstado);
        }

        public ActionResult RedirigirVistaEstado()
        {
            return View(this.rutaVistaEstado);
        }
        /*------------------------------FORMATO------------------------------*/
        public ActionResult AgregarFormato(Formato formato)
        {
            new LogicaFormato().AgregarFormato(formato.Nombre);
            return View(this.rutaVistaFormato);
        }

        public ActionResult EliminarFormato(string id)
        {
            new LogicaFormato().EliminarFormato(id);
            return View(this.rutaVistaFormato);
        }

        public ActionResult RedirigirVistaFormato()
        {
            return View(this.rutaVistaFormato);
        }

        /*------------------------------VENTAS------------------------------*/
        public ActionResult RedirigirVistaVentas()
        {
            return View("VistaVentas");
        }
    }
}