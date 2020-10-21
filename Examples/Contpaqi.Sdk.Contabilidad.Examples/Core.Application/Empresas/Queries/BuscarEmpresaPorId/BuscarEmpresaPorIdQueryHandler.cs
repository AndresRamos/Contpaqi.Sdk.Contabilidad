using System.Threading;
using System.Threading.Tasks;
using Core.Application.Empresas.Interfaces;
using Core.Application.Empresas.Models;
using MediatR;

namespace Core.Application.Empresas.Queries.BuscarEmpresaPorId
{
    public class BuscarEmpresaPorIdQueryHandler : IRequestHandler<BuscarEmpresaPorIdQuery, EmpresaDto>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public BuscarEmpresaPorIdQueryHandler(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Task<EmpresaDto> Handle(BuscarEmpresaPorIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_empresaRepository.BuscarEmpresaPorId(request.EmpresaId));
        }
    }
}