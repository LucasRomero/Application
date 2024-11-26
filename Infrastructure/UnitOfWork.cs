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
        private IOrdenRepository _ordenesInversionRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrdenRepository OrdenesInversion =>
            _ordenesInversionRepository ??= new OrdenRepository(_context);

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
