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
    public class GetAllActivosQueryHandler : IRequestHandler<GetAllActivosQuery, Result<IEnumerable<Activo>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllActivosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Activo>>> Handle(GetAllActivosQuery request, CancellationToken cancellationToken)
        {
            var activos = await _unitOfWork.ActivoRepository.GetAllAsync();

            return Result<IEnumerable<Activo>>.Success(activos);
        }
    }
}
