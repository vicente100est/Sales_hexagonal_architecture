
namespace AppVenta.Dominio.Interfaces.Repository
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>,
        IListar<TEntidad, TEntidadID>, ITransaccion
    {
    }
}
