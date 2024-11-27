using Application.Exceptions;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.GetById
{
    internal sealed class GetOrdenByIdQueryHandler : IRequestHandler<GetOrdenByIdQuery, Result<Orden>>
    {

        private readonly IUnitOfWork _unitOfWork;
        public GetOrdenByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Orden>> Handle(GetOrdenByIdQuery request, CancellationToken cancellationToken)
        {
            var orden = await _unitOfWork.OrdenesRepository.GetByIdAsync(request.Id);

            if (orden is null)
            {
                return Result<Orden>.Failure($"Orden con Id {request.Id} no encontrada");
            }

            return Result<Orden>.Success(orden);

        }
    }
}
