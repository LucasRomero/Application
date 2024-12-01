using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors
{
    public static class OrdenErrors
    {
        public static Error NotFound(int Id) => Error.NotFound(
        "Orden.NotFound",
        $"Orden con ID {Id} no existente.");

        public static Error NotFoundOrdenByIdUser(int Id) => Error.NotFound(
        "Orden.NotFound",
        $"El usuario de ID: {Id} no contiene Ordenes asociadas.");

    }
}
