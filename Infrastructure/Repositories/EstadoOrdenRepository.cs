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
    public sealed class EstadoOrdenRepository : IEstadoOrdenRepository
    {
        private readonly ApplicationDbContext _context;

        public EstadoOrdenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EstadoOrden?> GetByIdAsync(int id)
        {
            return await _context.EstadosOrden.FindAsync(id);
        }

        public async Task<IEnumerable<EstadoOrden>> GetAllAsync()
        {
            return await _context.EstadosOrden.ToListAsync();
        }

        public async Task AddAsync(EstadoOrden estado)
        {
            await _context.EstadosOrden.AddAsync(estado);
        }

        public async Task Update(EstadoOrden estado)
        {
             _context.EstadosOrden.Update(estado);
        }

        public async Task Delete(EstadoOrden estado)
        {
            _context.EstadosOrden.Remove(estado);
        }
    }
}
