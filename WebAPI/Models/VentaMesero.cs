using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class VentaMesero
    {
        [Key]
        public int Mesero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Suma { get; set; }

    }
}
