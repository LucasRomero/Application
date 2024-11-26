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
    public class GetAllActivosQueryHandler : IRequestHandler<GetAllActivosQuery, IEnumerable<Activo>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllActivosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<IEnumerable<Activo>> IRequestHandler<GetAllActivosQuery, IEnumerable<Activo>>.Handle(GetAllActivosQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ActivoRepository.GetAllAsync();

        }
    }
}
