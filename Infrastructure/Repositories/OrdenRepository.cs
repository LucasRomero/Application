using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreInfrastructure;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            _context.Entry(orden).State = EntityState.Added;
            await _context.OrdenesInversion.AddAsync(orden);
        }

        public async Task Update(Orden orden)
        {
            _context.Entry(orden).State = EntityState.Modified;
            _context.OrdenesInversion.Update(orden);
        }

        public async Task Delete(Orden orden)
        {
            _context.Entry(orden).State = EntityState.Deleted;
            _context.OrdenesInversion.Remove(orden);
        }

        public async Task<IEnumerable<Orden>> GetByIdUserAsync(int id)
        {
            return await _context.OrdenesInversion.Where(x => x.CuentaId == id).ToListAsync();
        }

        public async Task<IEnumerable<Orden>> GetAllByIdActivoAsync(int id)
        {
            return await _context.OrdenesInversion.Where(x => x.ActivoId == id).ToListAsync();
        }
    }
}
