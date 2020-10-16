namespace Core.Application.Sesiones.Interfaces
{
    public interface ISesionService
    {
        bool ConexionInciada { get; }
        bool SesionUsuarioIniciada { get; }
        void IniciarConexion();
        void TerminarConexion();
        void IniciarSesionUsuario();
        void IniciarSesionUsuario(string nombreUsuario, string contrasena);
    }
}