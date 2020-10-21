using MediatR;

namespace Core.Application.Empresas.Commands.AbrirEmpresa
{
    public class AbrirEmpresaCommand : IRequest
    {
        public AbrirEmpresaCommand(string nombreBaseDatos)
        {
            NombreBaseDatos = nombreBaseDatos;
        }

        public string NombreBaseDatos { get; }
    }
}