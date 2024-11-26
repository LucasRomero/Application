using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Orden: BaseEntity
    {
        public int CuentaId { get; set; }
        public string NombreActivo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public char Operacion { get; set; } // 'C' para compra, 'V' para venta
        public int Estado { get; set; } // 0 = "En proceso"
        public decimal MontoTotal { get; set; }
        public TipoActivo TipoActivo { get; set; }
    }
}
