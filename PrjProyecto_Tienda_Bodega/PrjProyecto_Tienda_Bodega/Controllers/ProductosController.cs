using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PrjProyecto_Tienda_Bodega.Models;

namespace PrjProyecto_Tienda_Bodega.Controllers
{
    public class ProductosController : Controller
    {

        ProductosDAO dao_productos = new ProductosDAO();


        // GET: Productos
        public ActionResult ListadoProductos()
        {
            var listado = dao_productos.ListarProductos();
            //
            return View(listado);
        }

        // GET: Productos/Create
        public ActionResult InsertarProducto()
        {
            Productos obj = new Productos();

            return View(obj);
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult InsertarProducto(Productos objProd)
        {
            // validar que el modelo no tenga errores
            if (ModelState.IsValid == true)
            {
                ViewBag.MENSAJE = dao_productos.InsertarProducto(objProd);
            }
            //
            // ViewBag.LISTA_DISTRITOS = new SelectList(...);
            //
            return View(objProd);
        }

        // GET: Productos/Edit/5
        public ActionResult ActualizarProducto(int id)
        {
            // encontrar al cliente en base a su codigo
            var listado = dao_productos.ListarProductos();
            //
            Productos buscado = listado.Find(pro => pro.idProducto.Equals(id));
            //
            return View(buscado);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult ActualizarProducto(int id, Productos prodAct)
        {
            if (ModelState.IsValid == true)
            {
                ViewBag.MENSAJE = dao_productos.ActualizarProductos(prodAct);
            }
            //
            return View(prodAct);
        }


    }
}
