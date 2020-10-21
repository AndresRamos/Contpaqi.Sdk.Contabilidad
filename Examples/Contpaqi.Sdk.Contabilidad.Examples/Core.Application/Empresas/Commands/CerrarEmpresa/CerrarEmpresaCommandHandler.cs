using System.Threading;
using System.Threading.Tasks;
using Core.Application.Sesiones.Interfaces;
using MediatR;

namespace Core.Application.Empresas.Commands.CerrarEmpresa
{
    public class CerrarEmpresaCommandHandler : IRequestHandler<CerrarEmpresaCommand>
    {
        private readonly ISesionService _sesionService;

        public CerrarEmpresaCommandHandler(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        public Task<Unit> Handle(CerrarEmpresaCommand request, CancellationToken cancellationToken)
        {
            _sesionService.CierraEmpresa();

            return Unit.Task;
        }
    }
}