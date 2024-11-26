using BookStoreInfrastructure;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class TipoActivoRepository : ITipoActivoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoActivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TipoActivo?> GetByIdAsync(int id)
        {
            return await _context.TiposActivo.FindAsync(id);
        }

        public async Task<IEnumerable<TipoActivo>> GetAllAsync()
        {
            return await _context.TiposActivo.ToListAsync();
        }

        public async Task AddAsync(TipoActivo activo)
        {
            await _context.TiposActivo.AddAsync(activo);
        }

        public async Task Update(TipoActivo activo)
        {
             _context.TiposActivo.Update(activo);
        }

        public async Task Delete(TipoActivo activo)
        {
            _context.TiposActivo.Remove(activo);
        }
    }
}
