using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjProyecto_Tienda_Bodega.Models
{
    public class Clientes
    {
        public int idCliente { get; set; } 
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string celular { get; set; }
    }
}