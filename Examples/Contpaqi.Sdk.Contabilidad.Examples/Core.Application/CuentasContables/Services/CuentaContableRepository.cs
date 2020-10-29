using System.Collections.Generic;
using AutoMapper;
using Core.Application.Common.Helpers;
using Core.Application.CuentasContables.Interfaces;
using Core.Application.CuentasContables.Models;
using SDKCONTPAQNGLib;

namespace Core.Application.CuentasContables.Services
{
    public class CuentaContableRepository : ICuentaContableRepository
    {
        private readonly IMapper _mapper;
        private readonly TSdkCuenta _sdkCuenta;

        public CuentaContableRepository(TSdkCuenta sdkCuenta, IMapper mapper)
        {
            _sdkCuenta = sdkCuenta;
            _mapper = mapper;
        }

        public IEnumerable<CuentaContableDto> BuscarTodasPorCodigo()
        {
            var cuentasList = new List<CuentaContableDto>();

            var sdkResult = 0;
            _sdkCuenta.consultaPorCodigo_buscaPrimero(ref sdkResult);
            if (sdkResult == SdkResult.Success)
            {
                var cuenta = _mapper.Map<TSdkCuenta, CuentaContableDto>(_sdkCuenta);
                cuentasList.Add(cuenta);
            }

            do
            {
                _sdkCuenta.consultaPorCodigo_buscaSiguiente(ref sdkResult);
                if (sdkResult == SdkResult.Success)
                {
                    var cuenta = _mapper.Map<TSdkCuenta, CuentaContableDto>(_sdkCuenta);
                    cuentasList.Add(cuenta);
                }
            } while (sdkResult == SdkResult.Success);

            return cuentasList;
        }

        public IEnumerable<CuentaContableDto> BuscarTodasPorNombre()
        {
            var cuentasList = new List<CuentaContableDto>();

            var sdkResult = 0;
            _sdkCuenta.consultaPorNombre_buscaPrimero(ref sdkResult);
            if (sdkResult == SdkResult.Success)
            {
                var cuenta = _mapper.Map<TSdkCuenta, CuentaContableDto>(_sdkCuenta);
                cuentasList.Add(cuenta);
            }

            do
            {
                _sdkCuenta.consultaPorNombre_buscaSiguiente(ref sdkResult);
                if (sdkResult == SdkResult.Success)
                {
                    var cuenta = _mapper.Map<TSdkCuenta, CuentaContableDto>(_sdkCuenta);
                    cuentasList.Add(cuenta);
                }
            } while (sdkResult == SdkResult.Success);

            return cuentasList;
        }
    }
}