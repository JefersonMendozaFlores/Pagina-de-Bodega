using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PrjProyecto_Tienda_Bodega.Models;

namespace PrjProyecto_Tienda_Bodega.Controllers
{
    public class ClientesController : Controller
    {
        // definir las variables de los DAOs a utilizar
        ClientesDAO dao_cliente = new ClientesDAO();

        // GET: Clientes
        public ActionResult ListadoClientes()
        {
            var listado = dao_cliente.ListarClientes();
            //
            return View(listado);
        }


        // GET: Compras/Create
        public ActionResult ClienteInsertar()
        {
            Clientes obj = new Clientes();
            obj.fechaNacimiento = new DateTime(2000, 10, 10);

            return View(obj);
        }

        // POST: Compras/Create
        [HttpPost]
        public ActionResult ClienteInsertar(Clientes objCli)
        {
            // validar que el modelo no tenga errores
            if (ModelState.IsValid == true)
            {
                ViewBag.MENSAJE = dao_cliente.InsertarCliente(objCli);
            }
            //
            // ViewBag.LISTA_DISTRITOS = new SelectList(...);
            //
            return View(objCli);
        }

        // GET: Clientes/Edit/5
        public ActionResult ActualizarCliente(int id)
        {
            // encontrar al cliente en base a su codigo
            var listado = dao_cliente.ListarClientes();
            //
            Clientes buscado = listado.Find(pro => pro.idCliente.Equals(id));
            //
            return View(buscado);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult ActualizarCliente(int id, Clientes cliAct)
        {
            if (ModelState.IsValid == true)
            {
                ViewBag.MENSAJE = dao_cliente.ActualizarCliente(cliAct);
            }
            //
            return View(cliAct);
        }

    }
}
