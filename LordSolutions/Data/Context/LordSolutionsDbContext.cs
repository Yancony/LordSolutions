using LordSolutions.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Context
{
    public interface ILordSolutionsDbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Cliente> DetallesDeFacturas { get; set; }
        DbSet<Factura> Facturas { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<Proveedor> Proveedores { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class LordSolutionsDbContext : DbContext, ILordSolutionsDbContext
    {
        private readonly IConfiguration config;

        public LordSolutionsDbContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Cliente> DetallesDeFacturas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString(name: "MSSQL")); ;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
