using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors
{
    public static class TipoActivoErrors
    {
        public static Error NotFound(int Id) => Error.NotFound(
        "TipoActivo.NotFound",
        $"Tipo Activo con ID {Id} no existente.");

    }
}
