using Application.Exceptions;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.Get
{
    public class GetAllEstadosQueryHandler : IRequestHandler<GetAllEstadosQuery, Result<IEnumerable<EstadoOrden>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllEstadosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<EstadoOrden>>> Handle(GetAllEstadosQuery request, CancellationToken cancellationToken)
        {
            var estados = await _unitOfWork.EstadoOrdenRepository.GetAllAsync();

            return Result<IEnumerable<EstadoOrden>>.Success(estados);
        }
    }
}
