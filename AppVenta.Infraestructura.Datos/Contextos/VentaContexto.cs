using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Contextos
{
    public class VentaContexto : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalogo = VentasDb; Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new VentaConfig());
            modelBuilder.ApplyConfiguration(new VentaDetalleConfig());
        }
    }
}
