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

namespace Application.Features.Activos.Delete
{
    internal sealed class DeleteActivoCommandHandler : IRequestHandler<DeleteActivoCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteActivoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteActivoCommand command, CancellationToken cancellationToken)
        {

            Activo? activo = await _unitOfWork.ActivoRepository.GetByIdAsync(command.ActivoId);

            if (activo is null)
            {
                return Result.Failure(ActivoErrors.NotFound(command.ActivoId));
            }

            var ordenes = await _unitOfWork.OrdenesRepository.GetAllByIdActivoAsync(command.ActivoId);

            if (ordenes.Any())
            {
                return Result.Failure(ActivoErrors.OrdenesAsociadas(command.ActivoId));
            }

            await _unitOfWork.ActivoRepository.Delete(activo);
            await _unitOfWork.Commit();

            return Result.Success();
        }
    }
}
