using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjProyecto_Tienda_Bodega.Models
{
    public class ReVentas
    {
        public int idCliente { get; set; }
        public int idVendedor { get; set; }
        public DateTime fechaVenta { get; set; }
    }
}