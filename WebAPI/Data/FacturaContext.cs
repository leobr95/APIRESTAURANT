using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class FacturaContext : DbContext
    {
        public FacturaContext(DbContextOptions<FacturaContext> options) : base(options)
        {
        }

        public DbSet<Factura> FacturaItems { get; set; }

        public DbSet<FacturaCompleta> FacturaCompleta { get; set; }
        public DbSet<ConsumoCliente> ConsumoCliente { get; set; }
        public DbSet<MasVendido> MasVendido { get; set; }
        public DbSet<VentaMesero> VentaMesero { get; set; }
        public DbSet<DetalleFactura> DetalleFacturaItems { get; set; }
        public DbSet<Mesa> MesaItems { get; set; }

        public DbSet<Mesero> MeseroItems { get; set; }

        public DbSet<Cliente> ClienteItems { get; set; }
        public DbSet<Supervisor> SupervisorItems { get; set; }


    }
}
