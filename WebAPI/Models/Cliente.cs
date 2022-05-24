
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Cliente
    {
        [Key]
        public int ClientelId { get; set; }
        [Required]
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }


        public List<Factura> Facturas { get; set; }
    }
}
