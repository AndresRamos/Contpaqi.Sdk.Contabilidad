using Core.Application.Common.Helpers;
using Core.Application.Sesiones.Interfaces;
using SDKCONTPAQNGLib;

namespace Core.Application.Sesiones.Services
{
    public class SesionService : ISesionService
    {
        private readonly TSdkSesion _sdkSesion;

        public SesionService(TSdkSesion sdkSesion)
        {
            _sdkSesion = sdkSesion;
        }

        public bool EmpresaAbierta { get; private set; }

        public bool ConexionInciada { get; private set; }

        public bool SesionUsuarioIniciada { get; private set; }

        public void IniciarConexion()
        {
            if (_sdkSesion.conexionActiva == 0)
            {
                _sdkSesion.iniciaConexion();
            }

            if (_sdkSesion.conexionActiva == 1)
            {
                ConexionInciada = true;
            }
        }

        public void TerminarConexion()
        {
            if (ConexionInciada)
            {
                _sdkSesion.finalizaConexion();
                ConexionInciada = false;
            }
        }

        public void IniciarSesionUsuario()
        {
            _sdkSesion.firmaUsuario();

            if (_sdkSesion.ingresoUsuario == 1)
            {
                SesionUsuarioIniciada = true;
            }
        }

        public void IniciarSesionUsuario(string nombreUsuario, string contrasena)
        {
            _sdkSesion.firmaUsuarioParams(nombreUsuario, contrasena);

            if (_sdkSesion.ingresoUsuario == 1)
            {
                SesionUsuarioIniciada = true;
            }
        }

        public void AbrirEmpresa(string nombreBaseDatos)
        {
            var sdkResult = _sdkSesion.abreEmpresa(nombreBaseDatos);

            if (sdkResult == SdkResult.Success)
            {
                EmpresaAbierta = true;
            }
        }

        public void CierraEmpresa()
        {
            _sdkSesion.cierraEmpresa();

            EmpresaAbierta = false;
        }
    }
}