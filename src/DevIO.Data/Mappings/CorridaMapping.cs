using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class CorridaMapping : IEntityTypeConfiguration<Corrida>
    {
        public void Configure(EntityTypeBuilder<Corrida> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(200)");         
        }
    }
}