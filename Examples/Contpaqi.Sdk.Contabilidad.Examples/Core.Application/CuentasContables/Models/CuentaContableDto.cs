using System;

namespace Core.Application.CuentasContables.Models
{
    public class CuentaContableDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreIngles { get; set; }
        public string Tipo { get; set; }
        public string CuentaDeMayor { get; set; }
        public int AceptaSegmentoNegocio { get; set; }
        public int Moneda { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}