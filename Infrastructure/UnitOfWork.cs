using BookStoreInfrastructure;
using Core.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IOrdenRepository OrdenesRepository { get; }
        public ITipoActivoRepository TipoActivoRepository { get; }
        public IEstadoOrdenRepository EstadoOrdenRepository { get; }


        public UnitOfWork(
            ApplicationDbContext context,
            IOrdenRepository ordenRepository,
            ITipoActivoRepository tipoActivoRepository,
            IEstadoOrdenRepository estadoOrdenRepository)
        {
            _context = context;
            OrdenesRepository = ordenRepository;
            TipoActivoRepository = tipoActivoRepository;
            EstadoOrdenRepository = estadoOrdenRepository;
        }

        //public IOrdenRepository OrdenesInversion =>
        //    _ordenesInversionRepository ??= new OrdenRepository(_context);

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
