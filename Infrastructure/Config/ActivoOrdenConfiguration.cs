using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class ActivoOrdenConfiguration : IEntityTypeConfiguration<Activo>
    {

        public void Configure(EntityTypeBuilder<Activo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Ticker)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Precio)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder.HasOne(x => x.TipoActivo)
                .WithMany()
                .HasForeignKey(x => x.TipoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
