using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesignProNamespace.Models;

namespace DesignProNamespace.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            return View(ma.GetAll());
        }

        public ActionResult GetConversation(int id)
        {
            ManejadorMensaje ma = new ManejadorMensaje();
            return View(ma.GetConversation(id));
        }

        public ActionResult Details(int id)
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            Usuario art = ma.Get(id);
            return View(art);
        }

        public ActionResult DetailsMensaje(int id)
        {
            ManejadorMensaje ma = new ManejadorMensaje();
            Mensaje art = ma.Get(id);
            return View(art);
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult CreateMensaje()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMensaje(FormCollection collection)
        {
            try
            {
                ManejadorMensaje ma = new ManejadorMensaje();
                Mensaje art = new Mensaje()
                {
                    IdUsuarioEmisor = int.Parse(collection["idUsuarioEmisor"]),
                    IdUsuarioReceptor = int.Parse(collection["idUsuarioReceptor"]),
                    Contenido = collection["contenido"],
                    Leido = Boolean.Parse(collection["leido"]),
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


        public ActionResult Edit(int id)
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            Usuario art = ma.Get(id);
            return View(art);
        }

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

        public ActionResult Delete(int id)
        {
            ManejadorUsuario ma = new ManejadorUsuario();
            Usuario art = ma.Get(id);
            return View(art);
        }

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
