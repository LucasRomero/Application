using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreInfrastructure;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IOrdenRepository OrdenesRepository { get; }
        public ITipoActivoRepository TipoActivoRepository { get; }
        public IEstadoOrdenRepository EstadoOrdenRepository { get; }
        public IActivoRepository ActivoRepository { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IOrdenRepository ordenRepository,
            ITipoActivoRepository tipoActivoRepository,
            IEstadoOrdenRepository estadoOrdenRepository,
            IActivoRepository activoRepository
        )
        {
            _context = context;
            OrdenesRepository = ordenRepository;
            TipoActivoRepository = tipoActivoRepository;
            EstadoOrdenRepository = estadoOrdenRepository;
            ActivoRepository = activoRepository;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
