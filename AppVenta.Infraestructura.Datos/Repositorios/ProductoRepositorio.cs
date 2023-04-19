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
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {
        private readonly VentaContexto _db;

        public ProductoRepositorio(VentaContexto db)
        {
            _db = db;
        }

        public Producto Agregar(Producto entidad)
        {
            entidad.productoId = Guid.NewGuid();
            _db.Productos.Add(entidad);
            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productoSeleccionado = _db.Productos.Where(c => c.productoId == entidad.productoId)
                .FirstOrDefault();
            if (productoSeleccionado != null)
            {
                productoSeleccionado.nombre = entidad.nombre;
                productoSeleccionado.descripcion = entidad.descripcion;
                productoSeleccionado.costo = entidad.costo;
                productoSeleccionado.precio = entidad.precio;
                productoSeleccionado.cantidadEnStock = entidad.cantidadEnStock;

                _db.Entry(productoSeleccionado).State = EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var productoSeleccionado = _db.Productos.Where(c => c.productoId == entidadId)
                .FirstOrDefault();
            if (productoSeleccionado != null)
            {
                _db.Productos.Remove(productoSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            _db.SaveChanges();
        }

        public List<Producto> Listar() => _db.Productos.ToList();

        public Producto SeleccionarPorID(Guid entidadId)
        {
            var productoSeleccionado = _db.Productos.Where(c => c.productoId == entidadId)
                .FirstOrDefault();

            return productoSeleccionado;
        }
    }
}
