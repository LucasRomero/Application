using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Activo : BaseEntity
    {
        public string Nombre { get; set; }
        public string Ticker { get; set; }
        public decimal Precio { get; set; }

        public TipoActivo TipoActivo { get; set; }
        public int TipoId { get; set; }
    }
}
