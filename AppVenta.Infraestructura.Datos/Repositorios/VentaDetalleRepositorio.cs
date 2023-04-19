using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repository;
using AppVenta.Infraestructura.Datos.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Repositorios
{
    public class VentaDetalleRepositorio : IRepositorioDetalle<VentaDetalle, Guid>
    {
        private readonly VentaContexto _db;

        public VentaDetalleRepositorio(VentaContexto db)
        {
            _db = db;
        }

        public VentaDetalle Agregar(VentaDetalle entidad)
        {
            _db.VentaDetalles.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            _db.SaveChanges();
        }
    }
}
