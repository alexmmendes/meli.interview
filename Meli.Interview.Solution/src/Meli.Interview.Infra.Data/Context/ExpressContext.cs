using Meli.Interview.Domain.Model;
using Meli.Interview.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Meli.Interview.Infra.Data.Context
{
    public sealed class ExpressContext : DbContext
    {
        public ExpressContext(DbContextOptions<ExpressContext> options) : base(options) { }

        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BDExpress");

            // Cadastro
            modelBuilder.ApplyConfiguration(new PedidoMap());
        }
    }
}
