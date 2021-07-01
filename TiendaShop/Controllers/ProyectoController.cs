using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaShop.Models;

namespace TiendaShop.Controllers
{
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            return View(ma.GetAll());
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int id)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Proyecto art = ma.Get(id);
            return View(art);
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyecto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ManejadorProyecto ma = new ManejadorProyecto();
                Proyecto art = new Proyecto()
                {
                    Titulo = collection["titulo"],
                    Visitas = int.Parse(collection["visitas"]),
                    RutaImgPortada = collection["rutaImgPortada"],
                    PromedioValoraciones = float.Parse(collection["promedioValoraciones"]),
                    FechaCreado = DateTime.Parse(collection["fechaCreado"]),
                    IdCategoria = int.Parse(collection["idCategoria"]),
                    IdUsuario = int.Parse(collection["idUsuario"]),
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

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int id)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Proyecto art = ma.Get(id);
            return View(art);
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ManejadorProyecto ma = new ManejadorProyecto();
                Proyecto art = new Proyecto()
                {
                    Id = id,
                    Titulo = collection["titulo"],
                    Visitas = int.Parse(collection["visitas"]),
                    RutaImgPortada = collection["rutaImgPortada"],
                    PromedioValoraciones = float.Parse(collection["promedioValoraciones"]),
                    FechaCreado = DateTime.Parse(collection["fechaCreado"]),
                    IdCategoria = int.Parse(collection["idCategoria"]),
                    IdUsuario = int.Parse(collection["idUsuario"]),
                };
                ma.Update(art);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Delete/5
        public ActionResult Delete(int id)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Proyecto art = ma.Get(id);
            return View(art);
        }

        // POST: Proyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ManejadorProyecto ma = new ManejadorProyecto();
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
