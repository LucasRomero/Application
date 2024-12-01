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

namespace Application.Features.Ordenes.Create
{
    public sealed record CreateOrdenCommand : ICommand<Result<int>>
    {
        public int Cantidad { get; set; }
        public string Operacion { get; set; }
        public int ActivoId { get; set; }
        public Activo? Activo { get; set; }
        public int CuentaId { get; set; }

    }
}
