﻿using Application.Exceptions;
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
    internal sealed class CrearOrdenCommandHandler : IRequestHandler<CrearOrdenCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearOrdenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CrearOrdenCommand request, CancellationToken cancellationToken)
        {

            var activo = new Activo();

            if (request.Activo == null)
            {
                activo = await _unitOfWork.ActivoRepository.GetByIdAsync(request.ActivoId);
                if (activo == null)
                {
                    return Result<int>.Failure($"Activo con ID {request.ActivoId} no encontrado.");
                }
            }

            var tipoActivo = await _unitOfWork.TipoActivoRepository.GetByIdAsync(request.TipoActivoId);
            if (tipoActivo == null)
            {
                return Result<int>.Failure($"Tipo de activo con ID {request.TipoActivoId} no encontrado.");
            }

            var estadoOrden = await _unitOfWork.EstadoOrdenRepository.GetByIdAsync(request.EstadoId);
            if (estadoOrden == null)
            {
                return Result<int>.Failure($"Estado con ID {request.EstadoId} no encontrado.");
            }

            request.Estado = estadoOrden;
            request.TipoActivo = tipoActivo;
            request.Activo = activo;

            var orden = new Orden
            {
                Cantidad = request.Cantidad,
                Operacion = request.Operacion,
                MontoTotal = CalcularMontoTotal(request),
                EstadoId = request.EstadoId,
                TipoActivoId = request.TipoActivoId,
                CuentaId = request.CuentaId
            };


            await _unitOfWork.OrdenesRepository.AddAsync(orden);
            await _unitOfWork.Commit();

            return Result<int>.Success(orden.Id);
        }



        private decimal CalcularMontoTotal(CrearOrdenCommand request)
        {
            return request.TipoActivo.Id switch
            {
                (int)TiposActivo.FCI => request.Activo.Precio * request.Cantidad,
                (int)TiposActivo.Accion => CalcularAccion(request),
                (int)TiposActivo.Bono => CalcularBono(request),
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
            var monto = request.Activo.Precio * request.Cantidad;
            var comisiones = monto * 0.002m;
            var impuestos = comisiones * 0.21m;
            return monto - (comisiones + impuestos);
        }

    }
}
