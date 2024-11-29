using Application.Abstractions.Messaging;
using Application.Exceptions;
using Core.Entities;
using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Update
{
    public sealed record UpdateOrdenCommand : ICommand<Result<int>>
    {
        public int IdOrden { get; set; }
        public int EstadoId { get; set; }
    }
}
