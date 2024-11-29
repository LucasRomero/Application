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

namespace Application.Features.Ordenes.Update
{
    internal sealed class UpdateOrdenCommandHandler : IRequestHandler<UpdateOrdenCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrdenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateOrdenCommand request, CancellationToken cancellationToken)
        {

            var orden = await _unitOfWork.OrdenesRepository.GetByIdAsync(request.IdOrden);
            if (orden is null)
            {
                return Result.Failure($"Estado con ID {request.EstadoId} no encontrado.");
            }

            var estadoOrden = await _unitOfWork.EstadoOrdenRepository.GetByIdAsync(request.EstadoId);
            if (estadoOrden is null)
            {
                return Result.Failure($"Estado con ID {request.EstadoId} no encontrado.");
            }

            orden.EstadoId = request.EstadoId;

            await _unitOfWork.OrdenesRepository.Update(orden);
            await _unitOfWork.Commit();

            return Result<Orden>.Success(orden);
        }

    }
}
