using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Interfaces.Repository
{
    public interface IRepositorioDetalle<TEntidad, TMovimientoID>
        : IAgregar<TEntidad>, ITransaccion
    {
    }
}
