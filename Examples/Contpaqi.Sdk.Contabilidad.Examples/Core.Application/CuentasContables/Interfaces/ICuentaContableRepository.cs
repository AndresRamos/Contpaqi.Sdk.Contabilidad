using System.Collections.Generic;
using Core.Application.CuentasContables.Models;

namespace Core.Application.CuentasContables.Interfaces
{
    public interface ICuentaContableRepository
    {
        IEnumerable<CuentaContableDto> BuscarTodasPorCodigo();
        IEnumerable<CuentaContableDto> BuscarTodasPorNombre();
    }
}