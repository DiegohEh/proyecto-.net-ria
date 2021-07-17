using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesignProNamespace.Models;

namespace DesignProNamespace.Controllers
{
    /*public class MainController : Controller
    {
        public Proyecto Model1 { get; set; }
        public Tag Model2 { get; set; }
        public Seccion Model3 { get; set; }
    }*/

    public class ProyectoController : Controller
    {
        public ActionResult Index()
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            return View(ma.GetAll());
        }

        public ActionResult GetRecientes()
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            return View(ma.GetRecientes());
        }

        public ActionResult GetMayorValorado()
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            return View(ma.GetMayorValorado());
        }

        public ActionResult Details(int id)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Proyecto art = ma.Get(id);
            return View(art);
        }

        public ActionResult GetByTitulo(string titulo)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Proyecto art = ma.GetByTitulo(titulo);
            return View(art);
        }
        public void GetBarraDeBusqueda(string busqueda)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            ma.GetBarraDeBusqueda(busqueda);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(FormCollection collection)
        {
            try
            {
                ManejadorProyecto ma = new ManejadorProyecto();
                Proyecto art = new Proyecto()
                {
                    Titulo = collection["titulo"],
                    Visitas = 0,
                    RutaImgPortada = collection["rutaImgPortada"],
                    PromedioValoraciones = 0,
                    FechaCreado = DateTime.Parse("2021/05/05"),
                    IdCategoria = int.Parse(collection["idCategoria"]),
                    IdUsuario = int.Parse(collection["idUsuario"]),
                };

                Tag tag = new Tag()
                {
                    IdProyecto = 0,
                    Nombre = collection["nombre"],
                };

                Seccion sec = new Seccion()
                {
                    IdProyecto = 0,
                    contenidoTexto = collection["contenidoTexto"],
                    rutaUrlImagen = collection["rutaUrlImagen"],
                    rutaUrlVideo = collection["rutaUrlVideo"],
                };

                ma.Create(art,tag,sec);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                //return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Proyecto art = ma.Get(id);
            return View(art);
        }

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

        public ActionResult UpdateValoraciones(int id)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Valoracion art = ma.GetValoracionId(id);
            return View(art);
        }

        [HttpPost]
        public ActionResult UpdateValoraciones(int id, FormCollection collection)
        {
            try
            {
                ManejadorProyecto ma = new ManejadorProyecto();
                Valoracion art = new Valoracion()
                {
                    IdProyecto= int.Parse(collection["idProyecto"]),
                    IdUsuario = int.Parse(collection["idUsuario"]),
                    Valor = float.Parse(collection["valor"]),
                };
                ma.UpdateValoraciones(art);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            ManejadorProyecto ma = new ManejadorProyecto();
            Proyecto art = ma.Get(id);
            return View(art);
        }

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

        public ActionResult CreateSeccion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSeccion(FormCollection collection)
        {
            try
            {
                ManejadorSeccion ma = new ManejadorSeccion();
                Seccion art = new Seccion()
                {
                    IdProyecto = int.Parse(collection["idProyecto"]),
                    contenidoTexto = collection["contenidoTexto"],
                    rutaUrlImagen = collection["rutaUrlImagen"],
                    rutaUrlVideo = collection["rutaUrlVideo"],
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

        public ActionResult GetSeccion(int id)
        {
            ManejadorSeccion ma = new ManejadorSeccion();
            Seccion art = ma.GetSeccion(id);
            return View(art);
        }

        public ActionResult UpdateSeccion(int id)
        {
            ManejadorSeccion ma = new ManejadorSeccion();
            Seccion art = ma.GetSeccion(id);
            return View(art);
        }

        [HttpPost]
        public ActionResult UpdateSeccion(int id, FormCollection collection)
        {
            try
            {
                ManejadorSeccion ma = new ManejadorSeccion();
                Seccion art = new Seccion()
                {
                    Id = id,
                    IdProyecto = int.Parse(collection["idProyecto"]),
                    contenidoTexto = collection["contenidoTexto"],
                    rutaUrlImagen = collection["rutaUrlImagen"],
                    rutaUrlVideo = collection["rutaUrlVideo"],
                };
                ma.UpdateSeccion(art);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DetailsComentario(int id)
        {
            ManejadorComentario ma = new ManejadorComentario();
            Comentario art = ma.Get(id);
            return View(art);
        }

        public ActionResult ListaComentario(int id)
        {
            ManejadorComentario ma = new ManejadorComentario();
            return View(ma.GetByProyecto(id));
        }

        public ActionResult CreateComentario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComentario(FormCollection collection)
        {
            try
            {
                ManejadorComentario ma = new ManejadorComentario();
                Comentario art = new Comentario()
                {
                    IdProyecto = int.Parse(collection["idProyecto"]),
                    IdUsuario = int.Parse(collection["idUsuario"]),
                    Contenido = collection["contenido"],
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
    }
}
