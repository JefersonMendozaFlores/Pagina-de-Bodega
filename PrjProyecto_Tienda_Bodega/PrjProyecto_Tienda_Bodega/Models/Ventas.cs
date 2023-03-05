using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjProyecto_Tienda_Bodega.Models
{
    public class Ventas
    {
        public int idVenta { get; set; }
        public string nombresCliente { get; set; }
        public string nombreVendedor { get; set; }
        public DateTime fechaVenta { get; set; }
        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }

    }
}