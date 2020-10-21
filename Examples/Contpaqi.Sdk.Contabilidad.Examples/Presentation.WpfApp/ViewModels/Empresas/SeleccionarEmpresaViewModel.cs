using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using Core.Application.Empresas.Models;
using Core.Application.Empresas.Queries.BuscarTodasLasEmpresas;
using MahApps.Metro.Controls.Dialogs;
using MediatR;

namespace Presentation.WpfApp.ViewModels.Empresas
{
    public sealed class SeleccionarEmpresaViewModel : Screen
    {
        private readonly IMediator _mediator;
        private EmpresaDto _empresaSeleccionada;
        private string _filtro;
        private readonly IDialogCoordinator _dialogCoordinator;

        public SeleccionarEmpresaViewModel(IMediator mediator, IDialogCoordinator dialogCoordinator)
        {
            _mediator = mediator;
            _dialogCoordinator = dialogCoordinator;
            DisplayName = "Seleccionar Empresa";
            EmpresaView = CollectionViewSource.GetDefaultView(Empresas);
            EmpresaView.Filter = EmpresasView_Filter;
        }

        public string Filtro
        {
            get => _filtro;
            set
            {
                if (value == _filtro)
                {
                    return;
                }

                _filtro = value;
                NotifyOfPropertyChange(() => Filtro);
                EmpresaView.Refresh();
            }
        }

        public BindableCollection<EmpresaDto> Empresas { get; } = new BindableCollection<EmpresaDto>();

        public ICollectionView EmpresaView { get; }

        public EmpresaDto EmpresaSeleccionada
        {
            get => _empresaSeleccionada;
            set
            {
                if (Equals(value, _empresaSeleccionada))
                {
                    return;
                }

                _empresaSeleccionada = value;
                NotifyOfPropertyChange(() => EmpresaSeleccionada);
                RaiseGuards();
            }
        }

        public bool SeleccionoEmpresa { get; private set; }

        public bool CanSeleccionar => EmpresaSeleccionada != null;

        public async Task BuscarTodasLasEmpresasAsync()
        {
            try
            {
                Empresas.Clear();
                Empresas.AddRange(await _mediator.Send(new BuscarTodasLasEmpresasQuery()));
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
        }

        public void Seleccionar()
        {
            SeleccionoEmpresa = true;
            TryClose();
        }

        public void Cancelar()
        {
            SeleccionoEmpresa = false;
            EmpresaSeleccionada = null;
            TryClose();
        }

        private void RaiseGuards()
        {
            NotifyOfPropertyChange(() => CanSeleccionar);
        }

        private bool EmpresasView_Filter(object obj)
        {
            var empresa = obj as EmpresaDto;
            if (empresa is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return string.IsNullOrWhiteSpace(Filtro) ||
                   empresa.Id.ToString().IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   empresa.Nombre.IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   empresa.NombreBaseDatos.IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0;
            //empresa.RutaDatos.IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
            //empresa.RutaRespaldo.IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
            //empresa.UltimoArchivoRespaldo.IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}