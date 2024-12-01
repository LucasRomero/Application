using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Errors
{
    public static class EstadoErrors
    {
        public static Error NotFound(int Id) => Error.NotFound(
        "Estado.NotFound",
        $"Estado con ID {Id} no existente.");

    }
}
