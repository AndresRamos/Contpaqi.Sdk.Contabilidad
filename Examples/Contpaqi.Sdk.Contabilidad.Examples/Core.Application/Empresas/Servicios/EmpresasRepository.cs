using System.Collections.Generic;
using AutoMapper;
using Core.Application.Common.Helpers;
using Core.Application.Empresas.Interfaces;
using Core.Application.Empresas.Models;
using SDKCONTPAQNGLib;

namespace Core.Application.Empresas.Servicios
{
    public class EmpresasRepository : IEmpresaRepository
    {
        private readonly IMapper _mapper;
        private readonly TSdkListaEmpresas _sdkListaEmpresas;

        public EmpresasRepository(TSdkListaEmpresas sdkListaEmpresas, IMapper mapper)
        {
            _sdkListaEmpresas = sdkListaEmpresas;
            _mapper = mapper;
        }

        public IEnumerable<EmpresaDto> BuscarTodasLasEmpresas()
        {
            var empresas = new List<EmpresaDto>();

            var sdkResult = _sdkListaEmpresas.buscaPrimero();

            if (sdkResult == SdkResult.Success)
            {
                var empresa = _mapper.Map<TSdkListaEmpresas, EmpresaDto>(_sdkListaEmpresas);
                empresas.Add(empresa);
            }

            while (_sdkListaEmpresas.buscaSiguiente() == SdkResult.Success)
            {
                var empresa = _mapper.Map<TSdkListaEmpresas, EmpresaDto>(_sdkListaEmpresas);
                empresas.Add(empresa);
            }

            return empresas;
        }

        public EmpresaDto BuscarEmpresaPorId(int id)
        {
            var sdkResult = _sdkListaEmpresas.buscaPorId(id);
            if (sdkResult == SdkResult.Success)
            {
                return _mapper.Map<TSdkListaEmpresas, EmpresaDto>(_sdkListaEmpresas);
            }

            return null;
        }
    }
}