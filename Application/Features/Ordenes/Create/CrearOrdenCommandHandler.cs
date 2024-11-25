using Core.Entities;
using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Create
{
    public class CrearOrdenCommandHandler : IRequestHandler<CrearOrdenCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CrearOrdenCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CrearOrdenCommand request, CancellationToken cancellationToken)
        {
            var orden = new OrdenInversion
            {
                CuentaId = request.CuentaId,
                NombreActivo = request.NombreActivo,
                Cantidad = request.Cantidad,
                Operacion = request.Operacion,
                TipoActivo = request.TipoActivo,
                Estado = 0, // "En proceso"
            };

            // Lógica de cálculo para "Monto Total"
            switch (request.TipoActivo)
            {
                case TipoActivo.FCI:
                    orden.MontoTotal = request.Cantidad * request.Precio;
                    break;
                case TipoActivo.Accion:
                    var comisiones = 0.006m * request.Cantidad * request.Precio;
                    var impuestos = 0.21m * comisiones;
                    orden.MontoTotal = request.Cantidad * request.Precio + comisiones + impuestos;
                    break;
                case TipoActivo.Bono:
                    comisiones = 0.002m * request.Cantidad * request.Precio;
                    impuestos = 0.21m * comisiones;
                    orden.MontoTotal = request.Cantidad * request.Precio + comisiones + impuestos;
                    break;
            }

            _context.OrdenesInversion.Add(orden);
            await _context.SaveChangesAsync(cancellationToken);

            return orden.Id;
        }
    }
}
