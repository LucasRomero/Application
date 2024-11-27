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
    public class GetAllTiposQueryHandler : IRequestHandler<GetAllTiposQuery, Result<IEnumerable<TipoActivo>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllTiposQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<TipoActivo>>> Handle(GetAllTiposQuery request, CancellationToken cancellationToken)
        {
            var tipos = await _unitOfWork.TipoActivoRepository.GetAllAsync();

            return Result<IEnumerable<TipoActivo>>.Success(tipos);
        }
    }
}
