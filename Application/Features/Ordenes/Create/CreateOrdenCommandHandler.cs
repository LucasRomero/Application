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
    internal sealed class CreateOrdenCommandHandler : IRequestHandler<CreateOrdenCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrdenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateOrdenCommand request, CancellationToken cancellationToken)
        {

            var activo = await _unitOfWork.ActivoRepository.GetByIdAsync(request.ActivoId);
            if (activo == null)
            {
                return Result<int>.Failure($"Activo con ID {request.ActivoId} no encontrado.");
            }

            activo.TipoActivo = await _unitOfWork.TipoActivoRepository.GetByIdAsync(activo.TipoId);

            if (activo.TipoActivo is null)
            {
                return Result<int>.Failure($"Tipo de activo con ID {activo.TipoId} no encontrado.");
            }

            request.Activo = activo;

            var orden = new Orden
            {
                Cantidad = request.Cantidad,
                Operacion = request.Operacion,
                MontoTotal = CalcularMontoTotal(request),
                EstadoId = (int)EstadosOrden.EnProceso,
                CuentaId = request.CuentaId,
                ActivoId = request.ActivoId
            };


            await _unitOfWork.OrdenesRepository.AddAsync(orden);
            await _unitOfWork.Commit();

            return Result<int>.Success(orden.Id);
        }



        private decimal CalcularMontoTotal(CreateOrdenCommand request)
        {
            return request.Activo.TipoActivo.Id switch
            {
                (int)TiposActivo.FCI => request.Activo.Precio * request.Cantidad,
                (int)TiposActivo.Accion => CalcularAccion(request),
                (int)TiposActivo.Bono => CalcularBono(request),
                _ => throw new InvalidOperationException("Tipo de activo inválido")
            };
        }

        private decimal CalcularAccion(CreateOrdenCommand request)
        {
            var precioAccion = request.Activo.Precio;
            var monto = precioAccion * request.Cantidad;
            var comisiones = monto * 0.006m;
            var impuestos = comisiones * 0.21m;
            return monto - (comisiones + impuestos);
        }

        private decimal CalcularBono(CreateOrdenCommand request)
        {
            var monto = request.Activo.Precio * request.Cantidad;
            var comisiones = monto * 0.002m;
            var impuestos = comisiones * 0.21m;
            return monto - (comisiones + impuestos);
        }

    }
}