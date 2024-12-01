using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrdenRepository : IRepository<Orden>
    {
        Task<IEnumerable<Orden>> GetByIdUserAsync(int id);
        Task<IEnumerable<Orden>> GetAllByIdActivoAsync(int id);
    }
}
