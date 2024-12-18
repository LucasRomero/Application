﻿using Application.Errors;
using Application.Exceptions;
using Application.Features.Ordenes.Delete;
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
    internal sealed class DeleteOrdenCommandHandler : IRequestHandler<DeleteOrdenCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrdenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteOrdenCommand command, CancellationToken cancellationToken)
        {

            Orden? orden = await _unitOfWork.OrdenesRepository.GetByIdAsync(command.OrdenId);

            if (orden is null)
            {
                return Result.Failure(OrdenErrors.NotFound(command.OrdenId));
            }

            await _unitOfWork.OrdenesRepository.Delete(orden);
            await _unitOfWork.Commit();

            return Result.Success();
        }
    }
}
