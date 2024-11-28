using Application.Exceptions;
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
    internal sealed class UpdateOrdenCommandHandler : IRequestHandler<UpdateOrdenCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrdenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateOrdenCommand request, CancellationToken cancellationToken)
        {

            var orden = await _unitOfWork.OrdenesRepository.GetByIdAsync(request.IdOrden);
            if (orden is null)
            {
                return Result<int>.Failure($"Estado con ID {request.EstadoId} no encontrado.");
            }

            var estadoOrden = await _unitOfWork.EstadoOrdenRepository.GetByIdAsync(request.EstadoId);
            if (estadoOrden is null)
            {
                return Result<int>.Failure($"Estado con ID {request.EstadoId} no encontrado.");
            }

            var updateOrden = new Orden
            {
                Cantidad = orden.Cantidad,
                Operacion = orden.Operacion,
                MontoTotal = orden.MontoTotal,
                EstadoId = request.EstadoId,
                CuentaId = orden.CuentaId
            };

            await _unitOfWork.OrdenesRepository.AddAsync(orden);
            await _unitOfWork.Commit();

            return Result<int>.Success(orden.Id);
        }

    }
}
