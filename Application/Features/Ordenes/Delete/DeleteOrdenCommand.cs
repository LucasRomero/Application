using Application.Abstractions.Messaging;
using Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Delete
{
    public sealed record DeleteOrdenCommand(int OrdenId) : ICommand<Result>;
}
