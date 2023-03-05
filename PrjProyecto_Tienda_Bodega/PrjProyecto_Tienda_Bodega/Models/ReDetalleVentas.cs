using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjProyecto_Tienda_Bodega.Models
{
    public class ReDetalleVentas
    {
        public int idVenta { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
    }
}