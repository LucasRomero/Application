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
    internal class GetOrdenByIdUserQueryHandler : IRequestHandler<GetOrdenByIdUserQuery, Result<IEnumerable<Orden>>>
    {

        private readonly IUnitOfWork _unitOfWork;
        public GetOrdenByIdUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Orden>>> Handle(GetOrdenByIdUserQuery request, CancellationToken cancellationToken)
        {
            var orden = await _unitOfWork.OrdenesRepository.GetByIdUserAsync(request.IdUser);

            if (orden is null)
            {
                return Result<IEnumerable<Orden>>.Failure($"Orden con Id {request.IdUser} no encontrada");
            }

            return Result<IEnumerable<Orden>>.Success(orden);

        }
    }
}
