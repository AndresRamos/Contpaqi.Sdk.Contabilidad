using System.Threading;
using System.Threading.Tasks;
using Core.Application.Sesiones.Interfaces;
using MediatR;

namespace Core.Application.Sesiones.Commands.IniciarConexion
{
    public class IniciarConexionCommandHandler : IRequestHandler<IniciarConexionCommand>
    {
        private readonly ISesionService _sesionService;

        public IniciarConexionCommandHandler(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        public Task<Unit> Handle(IniciarConexionCommand request, CancellationToken cancellationToken)
        {
            _sesionService.IniciarConexion();

            return Unit.Task;
        }
    }
}