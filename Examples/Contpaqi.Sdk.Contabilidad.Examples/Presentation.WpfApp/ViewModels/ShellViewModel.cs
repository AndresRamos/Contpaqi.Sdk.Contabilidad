using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using Core.Application.Empresas.Commands.AbrirEmpresa;
using Core.Application.Empresas.Commands.CerrarEmpresa;
using Core.Application.Sesiones.Commands.IniciarConexion;
using Core.Application.Sesiones.Commands.IniciarSesionUsuario;
using Core.Application.Sesiones.Commands.IniciarSesionUsuarioParametros;
using Core.Application.Sesiones.Commands.TerminarConexion;
using Core.Application.Sesiones.Interfaces;
using MahApps.Metro.Controls.Dialogs;
using MediatR;
using Presentation.WpfApp.ViewModels.Empresas;

namespace Presentation.WpfApp.ViewModels
{
    public sealed class ShellViewModel : Screen
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        private readonly IMediator _mediator;
        private readonly ISesionService _sesionService;
        private readonly IWindowManager _windowManager;

        public ShellViewModel(IMediator mediator, IDialogCoordinator dialogCoordinator, ISesionService sesionService, IWindowManager windowManager)
        {
            _mediator = mediator;
            _dialogCoordinator = dialogCoordinator;
            _sesionService = sesionService;
            _windowManager = windowManager;
            DisplayName = "SDK CONTPAQi Contabilidad";
        }

        public bool CanIniciarConexionAsync => !_sesionService.ConexionInciada;
        public bool CanTerminarConexionAsync => _sesionService.ConexionInciada;
        public bool CanIniciarSesionUsuarioAsync => _sesionService.ConexionInciada && !_sesionService.SesionUsuarioIniciada;
        public bool CanIniciarSesionUsuarioParametrosAsync => _sesionService.ConexionInciada && !_sesionService.SesionUsuarioIniciada;

        public bool CanAbrirEmpresaAsync => _sesionService.ConexionInciada && _sesionService.SesionUsuarioIniciada && !_sesionService.EmpresaAbierta;

        public bool CanCerrarEmpresaAsync => _sesionService.ConexionInciada && _sesionService.SesionUsuarioIniciada && _sesionService.EmpresaAbierta;

        public async Task IniciarConexionAsync()
        {
            try
            {
                await _mediator.Send(new IniciarConexionCommand());
                await _dialogCoordinator.ShowMessageAsync(this, "Conexion Iniciada", "Conexion iniciada exitosamente.");
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
            finally
            {
                RaiseGuards();
            }
        }

        public async Task TerminarConexionAsync()
        {
            try
            {
                await _mediator.Send(new TerminarConexionCommand());
                await _dialogCoordinator.ShowMessageAsync(this, "Conexion Terminada", "La conexion fue terminada exitosamente.");
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
            finally
            {
                RaiseGuards();
            }
        }

        public async Task IniciarSesionUsuarioAsync()
        {
            try
            {
                await _mediator.Send(new IniciarSesionUsuarioCommand());
                if (_sesionService.SesionUsuarioIniciada)
                {
                    await _dialogCoordinator.ShowMessageAsync(this, "Sesion De Usuario Inicidada", "La sesion de usuario fue iniciada exitosamente.");
                }
                else
                {
                    await _dialogCoordinator.ShowMessageAsync(this, "Credenciales Invalidas", "No se puede inciar sesion de usuario.");
                }
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
            finally
            {
                RaiseGuards();
            }
        }

        public async Task IniciarSesionUsuarioParametrosAsync()
        {
            try
            {
                var dialogResult = await _dialogCoordinator.ShowLoginAsync(this, "Iniciar Sesion Usuario", "Proporcione sus credenciales de CONTPAQi Contabilidad");

                await _mediator.Send(new IniciarSesionUsuarioParametrosCommand(dialogResult.Username, dialogResult.Password));
                if (_sesionService.SesionUsuarioIniciada)
                {
                    await _dialogCoordinator.ShowMessageAsync(this, "Sesion De Usuario Inicidada", "La sesion de usuario fue iniciada exitosamente.");
                }
                else
                {
                    await _dialogCoordinator.ShowMessageAsync(this, "Credenciales Invalidas", "No se puede inciar sesion de usuario.");
                }
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
            finally
            {
                RaiseGuards();
            }
        }

        public async Task AbrirEmpresaAsync()
        {
            try
            {
                var viewModel = IoC.Get<SeleccionarEmpresaViewModel>();
                _windowManager.ShowDialog(viewModel);
                if (viewModel.SeleccionoEmpresa)
                {
                    var empresa = viewModel.EmpresaSeleccionada;
                    await _mediator.Send(new AbrirEmpresaCommand(empresa.NombreBaseDatos));

                    if (_sesionService.EmpresaAbierta)
                    {
                        await _dialogCoordinator.ShowMessageAsync(this, "Abrir Empresa", "La empresa fue abierta exitosamente");
                    }
                    else
                    {
                        await _dialogCoordinator.ShowMessageAsync(this, "Abrir Empresa", "La empresa no pudo abrirse.");
                    }
                }
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
            finally
            {
                RaiseGuards();
            }
        }

        public async Task CerrarEmpresaAsync()
        {
            try
            {
                await _mediator.Send(new CerrarEmpresaCommand());
                if (_sesionService.EmpresaAbierta == false)
                {
                    await _dialogCoordinator.ShowMessageAsync(this, "Cerrar Empresa", "La empresa se cerro exitosamente.");
                }
                else
                {
                    await _dialogCoordinator.ShowMessageAsync(this, "Cerrar Empresa", "La empresa no pudo cerrarse.");
                }
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
            finally
            {
                RaiseGuards();
            }
        }

        private void RaiseGuards()
        {
            NotifyOfPropertyChange(() => CanIniciarConexionAsync);
            NotifyOfPropertyChange(() => CanTerminarConexionAsync);
            NotifyOfPropertyChange(() => CanIniciarSesionUsuarioAsync);
            NotifyOfPropertyChange(() => CanIniciarSesionUsuarioParametrosAsync);
            NotifyOfPropertyChange(() => CanAbrirEmpresaAsync);
            NotifyOfPropertyChange(() => CanCerrarEmpresaAsync);
        }
    }
}