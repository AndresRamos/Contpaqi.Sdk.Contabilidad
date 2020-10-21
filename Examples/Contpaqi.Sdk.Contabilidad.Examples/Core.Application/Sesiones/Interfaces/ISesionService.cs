namespace Core.Application.Sesiones.Interfaces
{
    public interface ISesionService
    {
        bool ConexionInciada { get; }
        bool SesionUsuarioIniciada { get; }
        bool EmpresaAbierta { get; }
        void IniciarConexion();
        void TerminarConexion();
        void IniciarSesionUsuario();
        void IniciarSesionUsuario(string nombreUsuario, string contrasena);
        void AbrirEmpresa(string nombreBaseDatos);
        void CierraEmpresa();
    }
}