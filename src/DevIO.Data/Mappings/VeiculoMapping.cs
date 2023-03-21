using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Placa)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Modelo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            
            // 1 : N => Veiculo : Corridas
            builder.HasMany(c => c.Corridas)
                   .WithOne(p => p.Veiculo)
                   .HasForeignKey(p => p.VeiculoId);

            builder.ToTable("Veiculos");
        }
    }
}