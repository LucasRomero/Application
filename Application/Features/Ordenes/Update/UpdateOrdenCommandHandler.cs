using Application.Errors;
using Application.Exceptions;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Update
{
    internal sealed class UpdateOrdenCommandHandler : IRequestHandler<UpdateOrdenCommand, Result<Orden>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrdenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Orden>> Handle(UpdateOrdenCommand command, CancellationToken cancellationToken)
        {

            var orden = await _unitOfWork.OrdenesRepository.GetByIdAsync(command.IdOrden);
            if (orden is null)
            {
                return Result<Orden>.Failure(OrdenErrors.NotFound(command.IdOrden));
            }

            var estadoOrden = await _unitOfWork.EstadoOrdenRepository.GetByIdAsync(command.EstadoId);
            if (estadoOrden is null)
            {
                return Result<Orden>.Failure(OrdenErrors.NotFound(command.IdOrden));
            }

            orden.EstadoId = command.EstadoId;

            await _unitOfWork.OrdenesRepository.Update(orden);
            await _unitOfWork.Commit();

            return Result<Orden>.Success(orden);
        }

    }
}
