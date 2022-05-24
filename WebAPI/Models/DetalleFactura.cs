
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        [Required]
        public string Plato { get; set; }
        public int Valor { get; set; }
        public int SupervisorId { get; set; }
        public Supervisor Supervisor { get; set; }

        public List<Factura> Facturas { get; set; }
    }
}
