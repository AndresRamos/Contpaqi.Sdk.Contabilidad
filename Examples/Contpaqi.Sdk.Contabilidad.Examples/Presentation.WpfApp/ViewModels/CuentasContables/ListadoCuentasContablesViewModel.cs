using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using Core.Application.CuentasContables.Models;
using Core.Application.CuentasContables.Queries.BuscarCuentasContablesPorCodigo;
using Core.Application.CuentasContables.Queries.BuscarCuentasContablesPorNombre;
using MahApps.Metro.Controls.Dialogs;
using MediatR;

namespace Presentation.WpfApp.ViewModels.CuentasContables
{
    public sealed class ListadoCuentasContablesViewModel : Screen
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        private readonly IMediator _mediator;
        private string _filtro;

        public ListadoCuentasContablesViewModel(IMediator mediator, IDialogCoordinator dialogCoordinator)
        {
            _mediator = mediator;
            _dialogCoordinator = dialogCoordinator;
            DisplayName = "Cuentas Contables";
            CuentasContablesView = CollectionViewSource.GetDefaultView(CuentasContables);
            CuentasContablesView.Filter = CuentasContablesView_Filter;
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
                CuentasContablesView.Refresh();
                NotifyOfPropertyChange(() => CuentasContablesViewCount);
            }
        }

        public BindableCollection<CuentaContableDto> CuentasContables { get; } = new BindableCollection<CuentaContableDto>();

        public ICollectionView CuentasContablesView { get; }

        public int CuentasContablesViewCount => CuentasContablesView.Cast<object>().Count();

        public async Task BuscarCuentasPorCodigoAsync()
        {
            try
            {
                CuentasContables.Clear();
                CuentasContables.AddRange(await _mediator.Send(new BuscarCuentasContablesPorCodigoQuery()));
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
            finally
            {
                NotifyOfPropertyChange(() => CuentasContablesViewCount);
            }
        }

        public async Task BuscarCuentasPorNombreAsync()
        {
            try
            {
                CuentasContables.Clear();
                CuentasContables.AddRange(await _mediator.Send(new BuscarCuentasContablesPorNombreQuery()));
            }
            catch (Exception e)
            {
                await _dialogCoordinator.ShowMessageAsync(this, "Error", e.ToString());
            }
        }

        private bool CuentasContablesView_Filter(object obj)
        {
            var cuenta = obj as CuentaContableDto;
            if (cuenta is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return string.IsNullOrWhiteSpace(Filtro) ||
                   cuenta.Id.ToString().IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   cuenta.Codigo.IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   cuenta.Nombre.IndexOf(Filtro, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}