using System.Threading;
using System.Threading.Tasks;
using Core.Application.Sesiones.Interfaces;
using MediatR;

namespace Core.Application.Sesiones.Commands.IniciarSesionUsuario
{
    public class IniciarSesionUsuarioCommandHandler : IRequestHandler<IniciarSesionUsuarioCommand>
    {
        private readonly ISesionService _sesionService;

        public IniciarSesionUsuarioCommandHandler(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        public Task<Unit> Handle(IniciarSesionUsuarioCommand request, CancellationToken cancellationToken)
        {
            _sesionService.IniciarSesionUsuario();

            return Unit.Task;
        }
    }
}