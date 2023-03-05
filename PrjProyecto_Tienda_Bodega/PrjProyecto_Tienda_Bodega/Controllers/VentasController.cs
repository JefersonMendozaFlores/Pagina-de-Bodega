using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PrjProyecto_Tienda_Bodega.Models;

namespace PrjProyecto_Tienda_Bodega.Controllers
{
    public class VentasController : Controller
    {
        // definir la variable del DAO
        VentasDAO dao_ventas = new VentasDAO();

        public ActionResult us_consulta_ventas(int idVenta= 0, int nropagina = 0)
        {
            // obtenemos los datos del modelo
            var listado = dao_ventas.us_consulta_ventas(idVenta);

            // definimos la variable del ViewBag para enviarlo a la vista
            ViewBag.IDVENTA = idVenta;
            //
            // enviamos los datos del modelo a la vista
            // return View(listado);

            // datos para la paginación
            // cantidad de filas por página
            int filas_pagina = 20;
            // cantidad total de filas del listado
            int cantidad = listado.Count;
            // obtener el numero de página a mostrar
            int paginas = 0;
            // si el resto sale mayor que cero, es decir, división no es exacta
            if (cantidad % filas_pagina > 0)
                paginas = (cantidad / filas_pagina) + 1;
            else
                paginas = cantidad / filas_pagina;

            //
            ViewBag.PAGINAS = paginas;
            //
            // saltamos hasta el registro "#" y desde ahi tomaremos los "n" siguientes registros
            return View(listado.Skip(nropagina * filas_pagina).Take(filas_pagina));
        }

        // GET: Productos/Create
        public ActionResult InsertarVenta()
        {
            ReVentas obj = new ReVentas();
            obj.fechaVenta = new DateTime(2023, 02, 10);

            return View(obj);
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult InsertarVenta(ReVentas objVenta)
        {
            // validar que el modelo no tenga errores
            if (ModelState.IsValid == true)
            {
                ViewBag.MENSAJE = dao_ventas.InsertarVenta(objVenta);
            }
            //
            // ViewBag.LISTA_DISTRITOS = new SelectList(...);
            //
            return View(objVenta);
        }

        // GET: Productos/Create
        public ActionResult InsertarDetalleVenta()
        {
            ReDetalleVentas obj = new ReDetalleVentas();

            return View(obj);
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult InsertarDetalleVenta(ReDetalleVentas objDetVenta)
        {
            // validar que el modelo no tenga errores
            if (ModelState.IsValid == true)
            {
                ViewBag.MENSAJE = dao_ventas.InsertarDetalleVenta(objDetVenta);
            }
            //
            // ViewBag.LISTA_DISTRITOS = new SelectList(...);
            //
            return View(objDetVenta);
        }
    }
}