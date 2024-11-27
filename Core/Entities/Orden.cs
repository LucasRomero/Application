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
        public int Cantidad { get; set; }
        public char Operacion { get; set; }

        public decimal MontoTotal { get; set; }
        public int ActivoId { get; set; }
        public Activo Activo { get; set; }
        public EstadoOrden EstadoOrden { get; set; }
        public int EstadoId { get; set; }
        public TipoActivo TipoActivo { get; set; }
        public int TipoActivoId { get; set; }

        public User User { get; set; }
        public int CuentaId { get; set; }
    }
}
