using Application.Exceptions;
using Application.Features.Ordenes.Get;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.Get
{
    public class GetAllOrdenesQueryHandler : IRequestHandler<GetAllOrdenesQuery, Result<IEnumerable<Orden>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrdenesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Orden>>> Handle(GetAllOrdenesQuery request, CancellationToken cancellationToken)
        {

           var ordenes = await _unitOfWork.OrdenesRepository.GetAllAsync();

           return Result<IEnumerable<Orden>>.Success(ordenes);

        }

    }
}
