using BookStoreInfrastructure;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class OrdenRepository : IOrdenRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Orden?> GetByIdAsync(int id)
        {
            return await _context.OrdenesInversion.FindAsync(id);
        }

        public async Task<IEnumerable<Orden>> GetAllAsync()
        {
            return await _context.OrdenesInversion.ToListAsync();
        }

        public async Task AddAsync(Orden orden)
        {
            await _context.OrdenesInversion.AddAsync(orden);
        }

        public async Task Update(Orden orden)
        {
             _context.OrdenesInversion.Update(orden);
        }

        public async Task Delete(Orden orden)
        {
            _context.OrdenesInversion.Remove(orden);
        }

        public async Task<IEnumerable<Orden>> GetByIdUserAsync(int id)
        {
            return await _context.OrdenesInversion.Where(x => x.CuentaId == id).ToListAsync();
        }
    }
}
