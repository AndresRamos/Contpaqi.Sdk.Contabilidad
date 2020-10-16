using MediatR;

namespace Core.Application.Sesiones.Commands.IniciarSesionUsuarioParametros
{
    public class IniciarSesionUsuarioParametrosCommand : IRequest
    {
        public IniciarSesionUsuarioParametrosCommand(string nombreUsuario, string contrasena)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
        }

        public string NombreUsuario { get; }
        public string Contrasena { get; }
    }
}