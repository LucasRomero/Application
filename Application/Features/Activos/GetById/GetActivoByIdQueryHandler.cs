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
    internal sealed class GetActivoByIdQueryHandler : IRequestHandler<GetActivoByIdQuery, Result>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetActivoByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetActivoByIdQuery request, CancellationToken cancellationToken)
        {

            var activo = await _unitOfWork.ActivoRepository.GetByIdAsync(request.Id);

            if (activo is null)
            {
                return Result.Failure("Activo no encontrado");
            }

            return Result<Activo>.Success(activo);
        }
    }
}
