using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jalisco.TimeTracker.Models.Models.Auth;
using Jalisco.TimeTracker.Models.Models.Configuracion;

namespace Jalisco.TimeTracker.API.Persistance.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<ConfigNotaDePedido> ConfigNotasDePedido { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigNotaDePedido>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(p => p.IdPlataforma).HasColumnName("PlataformaId").HasMaxLength(3).IsRequired();
                entity.Property(p => p.IdComprobante).HasColumnName("ComprobanteId").IsRequired();
                entity.Property(p => p.IdEmpresa).HasColumnName("EmpresaId").IsRequired();
                entity.HasOne(x => x.Empresa).WithMany(x => x.ConfigNotasDePedido).HasForeignKey(x => x.IdEmpresa);
                entity.HasIndex(x => new { x.IdEmpresa, x.IdPlataforma, x.IdComprobante });
                entity.ToTable("ConfigNotasDePedidos");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
