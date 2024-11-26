using Application.Abstractions.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.Delete
{
    public sealed record DeleteActivoCommand(int ActivoId) : ICommand;
}
