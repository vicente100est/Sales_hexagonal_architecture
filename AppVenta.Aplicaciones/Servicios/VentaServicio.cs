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
    public class VentaServicio : IServicioMovimiento<Venta, Guid>
    {
        private readonly IRepositorioMovimiento<Venta, Guid> _repoVenta;
        private readonly IRepositorioBase<Producto, Guid> _repoProducto;
        private readonly IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle;

        public VentaServicio(
            IRepositorioMovimiento<Venta, Guid> repoVenta,
            IRepositorioBase<Producto, Guid> repoProducto,
            IRepositorioDetalle<VentaDetalle, Guid> repoDetalle)
        {
            this._repoVenta = repoVenta;
            this._repoProducto = repoProducto;
            this._repoDetalle = repoDetalle;
        }

        public Venta Agregar(Venta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La 'Venta' es requerida");

            var ventaAgregada = _repoVenta.Agregar(entidad);

            entidad.VentaDetalles.ForEach(detalle =>
            {
                var productoSeleccionado = _repoProducto.SeleccionarPorID(detalle.productoId);
                if (productoSeleccionado == null)
                    throw new NullReferenceException("Usted esta intentando vender un producto que no existe >:v >:v >:v");

                detalle.ventaId = ventaAgregada.ventaId;
                detalle.productoId = detalle.productoId;
                detalle.costoUnitario = productoSeleccionado.costo;
                detalle.precioUnitario = productoSeleccionado.precio;
                detalle.cantidadVendida = detalle.cantidadVendida;
                detalle.subtotal = detalle.precioUnitario * detalle.cantidadVendida;
                detalle.impuesto = detalle.subtotal * 12 / 100;
                detalle.total = detalle.subtotal + detalle.impuesto;

                _repoDetalle.Agregar(detalle);

                productoSeleccionado.cantidadEnStock -= detalle.cantidadVendida;
                _repoProducto.Editar(productoSeleccionado);

                entidad.subtotal += detalle.subtotal;
                entidad.impuesto += detalle.impuesto;
                entidad.total += detalle.total;
            });

            _repoVenta.GuardarTodosLosCambios();

            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            _repoVenta.Anular(entidadId);
            _repoVenta.GuardarTodosLosCambios();
        }

        public List<Venta> Listar() => _repoVenta.Listar();

        public Venta SeleccionarPorID(Guid entidadId) => _repoVenta.SeleccionarPorID(entidadId);
    }
}
