using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.GetById
{
    public sealed class ActivoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ticker { get; set; }
        public decimal Precio { get; set; }
        public int TipoId { get; set; }
    }
}
