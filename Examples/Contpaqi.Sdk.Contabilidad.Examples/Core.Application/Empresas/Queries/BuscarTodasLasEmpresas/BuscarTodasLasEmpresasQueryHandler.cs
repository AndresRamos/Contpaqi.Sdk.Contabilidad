using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Empresas.Interfaces;
using Core.Application.Empresas.Models;
using MediatR;

namespace Core.Application.Empresas.Queries.BuscarTodasLasEmpresas
{
    public class BuscarTodasLasEmpresasQueryHandler : IRequestHandler<BuscarTodasLasEmpresasQuery, IEnumerable<EmpresaDto>>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public BuscarTodasLasEmpresasQueryHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Task<IEnumerable<EmpresaDto>> Handle(BuscarTodasLasEmpresasQuery request, CancellationToken cancellationToken)
        {
            var empresas = _empresaRepository.BuscarTodasLasEmpresas();
            return Task.FromResult(empresas);
        }
    }
}