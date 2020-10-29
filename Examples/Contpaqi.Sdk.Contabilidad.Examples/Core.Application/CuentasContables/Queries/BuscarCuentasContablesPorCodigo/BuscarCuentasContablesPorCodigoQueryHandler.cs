using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.CuentasContables.Interfaces;
using Core.Application.CuentasContables.Models;
using MediatR;

namespace Core.Application.CuentasContables.Queries.BuscarCuentasContablesPorCodigo
{
    public class BuscarCuentasContablesPorCodigoQueryHandler : IRequestHandler<BuscarCuentasContablesPorCodigoQuery, IEnumerable<CuentaContableDto>>
    {
        private readonly ICuentaContableRepository _cuentaContableRepository;

        public BuscarCuentasContablesPorCodigoQueryHandler(ICuentaContableRepository cuentaContableRepository)
        {
            _cuentaContableRepository = cuentaContableRepository;
        }

        public Task<IEnumerable<CuentaContableDto>> Handle(BuscarCuentasContablesPorCodigoQuery request, CancellationToken cancellationToken)
        {
            var cuentas = _cuentaContableRepository.BuscarTodasPorCodigo();
            return Task.FromResult(cuentas);
        }
    }
}