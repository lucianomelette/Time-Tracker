using Microsoft.AspNetCore.Identity;
using Jalisco.TimeTracker.Models.Models.Configuracion;
using System;

namespace Jalisco.TimeTracker.Models.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public int EmpresaId { get; set; }
        public string MonedaId { get; set; }
        public int GrupoDeVendedoresId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? FechaFija { get; set; }
        public Empresa Empresa { get; set; }
    }
}
