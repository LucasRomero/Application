using Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Features.Ordenes.Delete
{
    public sealed record DeleteOrdenCommand(int OrdenId) : IRequest<Result>;
}
