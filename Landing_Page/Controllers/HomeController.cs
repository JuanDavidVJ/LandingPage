using Landing_Page.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landing_Page.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        // POST: Home/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = new usuario
            {
                
                nombre = collection["nombre"].ToString(),
                celular = collection["celular"].ToString(),
                email = collection["email"].ToString(),
                ciudad = collection["ciudad"].ToString(),
            };
            if (ModelState.IsValid)
                return View("Thanks");
            else
                return View("Index");

            ma.Alta(usu);
            return RedirectToAction("Cualquiera");
        }
        public ActionResult Details(int id)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        
     

        public ActionResult BuscarTodos()
        {
            mantenimientousuario ma = new mantenimientousuario();
            return View(ma.RecuperarTodos());
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = new usuario
            {
                ID = id,
                nombre = collection["nombre"].ToString(),
                celular = collection["celular"].ToString(),
                email = collection["email"].ToString(),
                ciudad = collection["ciudad"].ToString(),


            };
            ma.Modificar(usu);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            mantenimientousuario ma = new mantenimientousuario();
            usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            mantenimientousuario ma = new mantenimientousuario();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }
        public ActionResult Cualquiera()
        {
            mantenimientousuario us = new mantenimientousuario();
            return View(us.RecuperarTodos());
        }
    }
}
