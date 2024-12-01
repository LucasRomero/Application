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

namespace Application.Features.Activos.GetById
{
    internal sealed class GetActivoByIdQueryHandler : IRequestHandler<GetActivoByIdQuery, Result<ActivoResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetActivoByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ActivoResponse>> Handle(GetActivoByIdQuery query, CancellationToken cancellationToken)
        {

            var activo = await _unitOfWork.ActivoRepository.GetByIdAsync(query.Id);

            var response = new ActivoResponse
            {
                Id = activo.Id,
                Nombre = activo.Nombre,
                Precio = activo.Precio,
                Ticker = activo.Ticker,
                TipoId = activo.TipoId,
            };

            if (activo is null)
            {
                return Result.Failure<ActivoResponse>(ActivoErrors.NotFound(query.Id));
            }

            return Result<ActivoResponse>.Success(response);
        }
    }
}
