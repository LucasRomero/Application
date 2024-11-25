using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Create
{
    public sealed record CrearOrdenCommand : IRequest<int>
    {
        public int CuentaId { get; set; }
        public string NombreActivo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public char Operacion { get; set; }
        public TipoActivo TipoActivo { get; set; }
    }
}
