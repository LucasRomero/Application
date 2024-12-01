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

        public static Error NotFoundOrdenByIdUser(int Id) => Error.Failure(
        "Orden.NotFound",
        $"El usuario de ID: {Id} no contiene Ordenes asociadas.");

        public static Error ErrorOperacion() => Error.Failure(
        "Orden.NotFound",
        "El Valor de operacion debe contener 'C' por compra o 'V' por venta.");

    }
}
