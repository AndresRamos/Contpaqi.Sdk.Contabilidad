using System.Collections.Generic;
using Core.Application.Empresas.Models;
using MediatR;

namespace Core.Application.Empresas.Queries.BuscarTodasLasEmpresas
{
    public class BuscarTodasLasEmpresasQuery : IRequest<IEnumerable<EmpresaDto>>
    {
    }
}