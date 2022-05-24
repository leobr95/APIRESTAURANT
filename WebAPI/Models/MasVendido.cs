using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MasVendido
    {
        [Key]
        public string Plato { get; set; }
        public int Cantidad { get; set; }
        public int Suma { get; set; }

    }
}
