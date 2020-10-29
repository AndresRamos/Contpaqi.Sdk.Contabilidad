using System.Collections.Generic;
using Core.Application.CuentasContables.Models;
using MediatR;

namespace Core.Application.CuentasContables.Queries.BuscarCuentasContablesPorNombre
{
    public class BuscarCuentasContablesPorNombreQuery : IRequest<IEnumerable<CuentaContableDto>>
    {
    }
}