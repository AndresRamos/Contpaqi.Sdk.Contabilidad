using System.Collections.Generic;
using Core.Application.Empresas.Models;

namespace Core.Application.Empresas.Interfaces
{
    public interface IEmpresaRepository
    {
        IEnumerable<EmpresaDto> BuscarTodasLasEmpresas();
        EmpresaDto BuscarEmpresaPorId(int id);
    }
}