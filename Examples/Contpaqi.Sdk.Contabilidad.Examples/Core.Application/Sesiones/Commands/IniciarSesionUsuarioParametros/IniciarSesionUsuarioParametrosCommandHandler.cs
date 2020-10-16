using System.Threading;
using System.Threading.Tasks;
using Core.Application.Sesiones.Interfaces;
using MediatR;

namespace Core.Application.Sesiones.Commands.IniciarSesionUsuarioParametros
{
    public class IniciarSesionUsuarioParametrosCommandHandler : IRequestHandler<IniciarSesionUsuarioParametrosCommand>
    {
        private readonly ISesionService _sesionService;

        public IniciarSesionUsuarioParametrosCommandHandler(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        public Task<Unit> Handle(IniciarSesionUsuarioParametrosCommand request, CancellationToken cancellationToken)
        {
            _sesionService.IniciarSesionUsuario(request.NombreUsuario, request.Contrasena);

            return Unit.Task;
        }
    }
}