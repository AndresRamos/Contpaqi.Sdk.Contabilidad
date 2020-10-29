using System.Collections.Generic;
using Core.Application.CuentasContables.Models;
using MediatR;

namespace Core.Application.CuentasContables.Queries.BuscarCuentasContablesPorCodigo
{
    public class BuscarCuentasContablesPorCodigoQuery : IRequest<IEnumerable<CuentaContableDto>>
    {
    }
}