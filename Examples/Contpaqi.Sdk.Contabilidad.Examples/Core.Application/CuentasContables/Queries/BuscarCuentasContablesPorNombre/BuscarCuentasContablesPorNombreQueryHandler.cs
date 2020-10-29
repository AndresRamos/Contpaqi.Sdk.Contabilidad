using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.CuentasContables.Interfaces;
using Core.Application.CuentasContables.Models;
using MediatR;

namespace Core.Application.CuentasContables.Queries.BuscarCuentasContablesPorNombre
{
    public class BuscarCuentasContablesPorNombreQueryHandler : IRequestHandler<BuscarCuentasContablesPorNombreQuery, IEnumerable<CuentaContableDto>>
    {
        private readonly ICuentaContableRepository _cuentaContableRepository;

        public BuscarCuentasContablesPorNombreQueryHandler(ICuentaContableRepository cuentaContableRepository)
        {
            _cuentaContableRepository = cuentaContableRepository;
        }

        public Task<IEnumerable<CuentaContableDto>> Handle(BuscarCuentasContablesPorNombreQuery request, CancellationToken cancellationToken)
        {
            var cuentas = _cuentaContableRepository.BuscarTodasPorNombre();
            return Task.FromResult(cuentas);
        }
    }
}