using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaShop.Models;

namespace TiendaShop.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            ManejadorArticulo ma = new ManejadorArticulo();
            return View(ma.GetAll());
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            ManejadorArticulo ma = new ManejadorArticulo();
            Articulo art = ma.Get(id);
            return View(art);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ManejadorArticulo ma = new ManejadorArticulo();
                Articulo art = new Articulo()
                {
                    Codigo = collection["codigo"],
                    Descripcion = collection["descripcion"],
                    Precio = float.Parse(collection["precio"])
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

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            ManejadorArticulo ma = new ManejadorArticulo();
            Articulo art = ma.Get(id);
            return View(art);
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ManejadorArticulo ma = new ManejadorArticulo();
                Articulo art = new Articulo()
                {
                    Id = id,
                    Codigo = collection["codigo"],
                    Descripcion = collection["descripcion"],
                    Precio = float.Parse(collection["precio"])
                };
                ma.Update(art);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            ManejadorArticulo ma = new ManejadorArticulo();
            Articulo art = ma.Get(id);
            return View(art);
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ManejadorArticulo ma = new ManejadorArticulo();
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
