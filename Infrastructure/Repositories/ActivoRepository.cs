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
    public sealed class ActivoRepository : IActivoRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activo?> GetByIdAsync(int id)
        {
            return await _context.Activos.FindAsync(id);
        }

        public async Task<IEnumerable<Activo>> GetAllAsync()
        {
            var hola = await _context.Activos.ToListAsync();

            return hola;
        }

        public async Task AddAsync(Activo activo)
        {
            await _context.Activos.AddAsync(activo);
        }

        public async Task Update(Activo activo)
        {
             _context.Activos.Update(activo);
        }

        public async Task Delete(Activo activo)
        {
            _context.Activos.Remove(activo);
        }
    }
}
