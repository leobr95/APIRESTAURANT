using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class FacturaCompleta
    {
        [Key]
        public int CodigoFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Plato { get; set; }
        public int Valor { get; set; }
        public string Supervisor { get; set; }
        public int NumeroMesa { get; set; }
        public string Mesa { get; set; }
        public int Puestos { get; set; }
        public int IdentificacionCliente { get; set; }
        public string NombreCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public int CodigoMesero { get; set; }
        public string NombreMesero { get; set; }


    }
}
