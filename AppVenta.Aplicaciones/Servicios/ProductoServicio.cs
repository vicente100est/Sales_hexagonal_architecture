using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces.Repository;
using AppVenta.Aplicaciones.Interfaces;

namespace AppVenta.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> _repoProducto;

        public ProductoServicio(IRepositorioBase<Producto, Guid> repositorioProducto)
        {
            this._repoProducto = repositorioProducto;
        }

        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Producto' es requerido");

            var resultProducto = _repoProducto.Agregar(entidad);
            _repoProducto.GuardarTodosLosCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Producto' es requerido");

            _repoProducto.Editar(entidad);
            _repoProducto.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            _repoProducto.Eliminar(entidadId);
            _repoProducto.GuardarTodosLosCambios();
        }

        public List<Producto> Listar() => _repoProducto.Listar();

        public Producto SeleccionarPorID(Guid entidadId) => _repoProducto.SeleccionarPorID(entidadId);
    }
}
