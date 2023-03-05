using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjProyecto_Tienda_Bodega.Models
{
    public class Productos
    {
        public int idProducto { get; set; }
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }
        public int stock { get; set; }
        public decimal precioUnitario { get; set; }
    }
}