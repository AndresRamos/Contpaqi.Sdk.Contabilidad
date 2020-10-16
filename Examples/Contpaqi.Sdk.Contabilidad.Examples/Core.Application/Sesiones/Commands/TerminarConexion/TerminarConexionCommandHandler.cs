using System.Threading;
using System.Threading.Tasks;
using Core.Application.Sesiones.Interfaces;
using MediatR;

namespace Core.Application.Sesiones.Commands.TerminarConexion
{
    public class TerminarConexionCommandHandler : IRequestHandler<TerminarConexionCommand>
    {
        private readonly ISesionService _sesionService;

        public TerminarConexionCommandHandler(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        public Task<Unit> Handle(TerminarConexionCommand request, CancellationToken cancellationToken)
        {
            _sesionService.TerminarConexion();

            return Unit.Task;
        }
    }
}