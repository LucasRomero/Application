using Core.Entities;
using Core.Enums;
using Core.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public CrearOrdenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearOrdenCommand request, CancellationToken cancellationToken)
        {
            var orden = new Orden
            {
                CuentaId = request.CuentaId,
                NombreActivo = request.NombreActivo,
                Cantidad = request.Cantidad,
                Operacion = request.Operacion,
                Precio = request.TipoActivo == TipoActivo.Accion ? 0 : request.Precio,
                MontoTotal = CalcularMontoTotal(request),
                Estado = (int)EstadoOrden.EnProceso
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

            await _unitOfWork.OrdenesInversion.AddAsync(orden);
            await _unitOfWork.Commit();

            return orden.Id;
        }



        private decimal CalcularMontoTotal(CrearOrdenCommand request)
        {
            return request.TipoActivo switch
            {
                TipoActivo.FCI => request.Precio * request.Cantidad,
                TipoActivo.Accion => CalcularAccion(request),
                TipoActivo.Bono => CalcularBono(request),
                _ => throw new InvalidOperationException("Tipo de activo inválido")
            };
        }

        private decimal CalcularAccion(CrearOrdenCommand request)
        {
            var precioAccion = 100; // Simulación, deberías traerlo de la BBDD.
            var monto = precioAccion * request.Cantidad;
            var comisiones = monto * 0.006m;
            var impuestos = comisiones * 0.21m;
            return monto - (comisiones + impuestos);
        }

        private decimal CalcularBono(CrearOrdenCommand request)
        {
            var monto = request.Precio * request.Cantidad;
            var comisiones = monto * 0.002m;
            var impuestos = comisiones * 0.21m;
            return monto - (comisiones + impuestos);
        }

    }
}
