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
    internal sealed class GetActivoByIdQueryHandler : IRequestHandler<GetActivoByIdQuery, Activo>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetActivoByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activo> Handle(GetActivoByIdQuery request, CancellationToken cancellationToken)
        {

            var activo = await _unitOfWork.ActivoRepository.GetByIdAsync(request.Id);

            if (activo is null)
            {
                return;   
            }



        }
    }
}
