using Meli.Interview.Domain.Core.Interfaces.Mapping;
using Meli.Interview.Domain.Model;
using Meli.Interview.Infra.Data.Mappings.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meli.Interview.Infra.Data.Mappings
{
    public sealed class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public static ITable<Pedido> GenerateTable() => new Table<Pedido>("MELI_INTERVIEW_PEDIDO");

        private readonly IDatabase database;

        public PedidoMap()
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            //builder.HasKey(p => p.Id);

            //builder.Property(x => x.Id)
            //    .HasColumnName("")
            //    .UseIdentityColumn()
            //    .IsRequired();

            //builder.Property(p => p.ProjetoId)
            //    .HasColumnName("")
            //    .IsRequired();

            //builder.Property(p => p.Descricao)
            //    .HasColumnName("")
            //    .HasMaxLength(250);


            builder.ToTable(database.GetTable<Pedido>()!.PhysicalName);
        }
    }
}
