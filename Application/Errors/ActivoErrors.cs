using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors
{
    public static class ActivoErrors
    {
        public static Error NotFound(int Id) => Error.NotFound(
        "Activo.NotFound",
        $"Activo con ID {Id} no existente.");

        public static Error OrdenesAsociadas (int Id) => Error.Problem(
        "Activo.NotFound",
        $"Activo con ID {Id} tiene Ordenes asociadas.");
    }
}
