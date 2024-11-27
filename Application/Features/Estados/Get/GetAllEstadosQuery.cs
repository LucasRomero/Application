using Application.Exceptions;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.Get
{
    public sealed class GetAllEstadosQuery : IRequest<Result<IEnumerable<EstadoOrden>>>;
}
