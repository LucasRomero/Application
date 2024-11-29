using Application.Exceptions;
using Application.Features.Activos.Create;
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
    internal sealed class CreateActivoCommandHandler : IRequestHandler<CreateActivoCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateActivoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateActivoCommand request, CancellationToken cancellationToken)
        {

            var activo = new Activo
            {
                Nombre = request.Nombre,
                Ticker = request.Ticker,
                Precio = request.Precio,
                TipoId = request.TipoId,
            };


            await _unitOfWork.ActivoRepository.AddAsync(activo);
            await _unitOfWork.Commit();

            return Result<int>.Success(activo.Id);
        }

    }
}
