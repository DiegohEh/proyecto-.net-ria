using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaShop.Models;

namespace TiendaShop.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            return View(ma.GetAll());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            Usuario art = ma.Get(id);
            return View(art);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ManejadorUsuario ma = new ManejadorUsuario();
                Usuario art = new Usuario()
                {
                    Email = collection["email"],
                    Contrasenia = collection["contrasenia"],
                    Nombre = collection["nombre"],
                    Apellido = collection["apellido"],
                    FechaNac = DateTime.Parse(collection["fechaNac"]),
                    Pais = collection["pais"],
                    Ciudad = collection["ciudad"],
                    RutaImgPerfil = collection["rutaImgPerfil"],
                    Profesion = collection["profesion"],
                    Empresa = collection["empresa"],
                    UrlSitioWebProfesional = collection["urlSitioWebProfesional"],
                    Descripcion = collection["descripcion"],
                    VisitasTotales = int.Parse(collection["visitasTotales"]),
                    PromedioValoraciones = float.Parse(collection["promedioValoraciones"])
                };
                ma.Create(art);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            Usuario art = ma.Get(id);
            return View(art);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ManejadorUsuario ma = new ManejadorUsuario();
                Usuario art = new Usuario()
                {
                    Id = id,
                    Email = collection["email"],
                    Contrasenia = collection["contrasenia"],
                    Nombre = collection["nombre"],
                    Apellido = collection["apellido"],
                    FechaNac = DateTime.Parse(collection["fechaNac"]),
                    Pais = collection["pais"],
                    Ciudad = collection["ciudad"],
                    RutaImgPerfil = collection["rutaImgPerfil"],
                    Profesion = collection["profesion"],
                    Empresa = collection["empresa"],
                    UrlSitioWebProfesional = collection["urlSitioWebProfesional"],
                    Descripcion = collection["descripcion"],
                    VisitasTotales = int.Parse(collection["visitasTotales"]),
                    PromedioValoraciones = float.Parse(collection["promedioValoraciones"])
                };
                ma.Update(art);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            Usuario art = ma.Get(id);
            return View(art);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ManejadorUsuario ma = new ManejadorUsuario();
                ma.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
