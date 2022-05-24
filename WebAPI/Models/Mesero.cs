
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Mesero
    {
        public int MeseroId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int Edad { get; set; }
        public int Antiguedad { get; set; }


        public List<Factura> Facturas { get; set; }
    }
}
