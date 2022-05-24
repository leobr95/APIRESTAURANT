
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Mesa
    {
        public int MesaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public bool Reservada { get; set; }
        public int Puestos { get; set; }


        public List<Factura> Facturas { get; set; }
    }
}
