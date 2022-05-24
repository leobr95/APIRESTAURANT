using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        [Required]
       
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int DetalleFacturaId { get; set; }
        public DetalleFactura DetalleFactura { get; set; }
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
        public int MeseroId { get; set; }
        public Mesero Mesero { get; set; }


    }
}
