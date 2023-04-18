using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Interfaces.Repository
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID entidadId);
    }
}
