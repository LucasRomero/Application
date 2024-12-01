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

namespace Application.Features.Ordenes.GetById
{
    internal sealed class GetOrdenByIdUserQueryHandler : IRequestHandler<GetOrdenByIdUserQuery, Result<IEnumerable<Orden>>>
    {

        private readonly IUnitOfWork _unitOfWork;
        public GetOrdenByIdUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Orden>>> Handle(GetOrdenByIdUserQuery query, CancellationToken cancellationToken)
        {
            var orden = await _unitOfWork.OrdenesRepository.GetByIdUserAsync(query.IdUser);

            if (orden is null)
            {
                return Result<IEnumerable<Orden>>.Failure(OrdenErrors.NotFoundOrdenByIdUser(query.IdUser));
            }

            return Result<IEnumerable<Orden>>.Success(orden);

        }
    }
}
