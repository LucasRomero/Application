using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.Delete
{
    internal sealed class DeleteActivoCommandHandler : IRequestHandler<DeleteActivoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteActivoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteActivoCommand request, CancellationToken cancellationToken)
        {

            Activo? activo = await _unitOfWork.ActivoRepository.GetByIdAsync(request.ActivoId);

            if (activo is null)
            {
                return;
            }

            await _unitOfWork.ActivoRepository.Delete(activo);
            await _unitOfWork.Commit();
        }
    }
}
