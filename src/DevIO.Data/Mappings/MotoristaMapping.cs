using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class MotoristaMapping : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasMany(c => c.CorridasPrimeiroMotorista)
              .WithOne(p => p.PrimeiroMotorista)
              .HasForeignKey(p => p.IdMotoristaPrimeiro);


            builder.HasMany(c => c.CorridasSegundoMotorista)
              .WithOne(p => p.SegundoMotorista)
              .HasForeignKey(p => p.IdMotoristaSegundo);

            //builder.HasMany(c => c.Corridas)
            //  .WithOne(p => p.SegundoMotorista)
            //  .HasForeignKey(p => p.IdMotoristaSegundo);


            builder.ToTable("Motoristas");
        }
    }
}