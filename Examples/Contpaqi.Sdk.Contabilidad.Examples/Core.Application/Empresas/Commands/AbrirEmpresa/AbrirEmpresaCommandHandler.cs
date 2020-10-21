using System.Threading;
using System.Threading.Tasks;
using Core.Application.Sesiones.Interfaces;
using MediatR;

namespace Core.Application.Empresas.Commands.AbrirEmpresa
{
    public class AbrirEmpresaCommandHandler : IRequestHandler<AbrirEmpresaCommand>
    {
        private readonly ISesionService _sesionService;

        public AbrirEmpresaCommandHandler(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        public Task<Unit> Handle(AbrirEmpresaCommand request, CancellationToken cancellationToken)
        {
            _sesionService.AbrirEmpresa(request.NombreBaseDatos);

            return Unit.Task;
        }
    }
}