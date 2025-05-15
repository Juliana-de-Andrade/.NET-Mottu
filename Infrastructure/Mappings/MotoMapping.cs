using challenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace challenger.Infrastructure.Mappings
{
    public class MotoMapping : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("Moto");

            builder
                .HasKey("Id");

            builder
                .Property(moto => moto.Placa)
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(moto => moto.Modelo)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(moto => moto.Status)
                .IsRequired();

            builder
                .Property(moto => moto.Created)
                .HasMaxLength (20)
                .IsRequired();
        }
    }
}
