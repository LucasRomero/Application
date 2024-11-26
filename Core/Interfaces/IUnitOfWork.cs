using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrdenRepository OrdenesRepository { get; }
        ITipoActivoRepository TipoActivoRepository { get; }
        IEstadoOrdenRepository EstadoOrdenRepository { get; }
        Task<int> Commit();
    }
}
