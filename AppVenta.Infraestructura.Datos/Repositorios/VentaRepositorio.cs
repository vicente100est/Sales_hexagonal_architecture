using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repository;
using AppVenta.Infraestructura.Datos.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Infraestructura.Datos.Repositorios
{
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {
        private readonly VentaContexto _db;

        public VentaRepositorio(VentaContexto db)
        {
            _db = db;
        }

        public Venta Agregar(Venta entidad)
        {
            entidad.ventaId = Guid.NewGuid();
            _db.Ventas.Add(entidad);
            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            var ventaSeleccionada = _db.Ventas.Where(v => v.ventaId == entidadId).FirstOrDefault();
            if (ventaSeleccionada == null)
                throw new NullReferenceException("Esta intentando anular una venta que no existe");

            ventaSeleccionada.anulado = true;
            _db.Entry(ventaSeleccionada).State = EntityState.Modified;
        }

        public void GuardarTodosLosCambios() => _db.SaveChanges();

        public List<Venta> Listar() => _db.Ventas.ToList();

        public Venta SeleccionarPorID(Guid entidadId)
        {
            var ventaSeleccionada = _db.Ventas.Where(v => v.ventaId == entidadId).FirstOrDefault();
            return ventaSeleccionada;
        }
    }
}
