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
    internal class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.CuentaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EstadoOrden)
                .WithMany()
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TipoActivo)
                .WithMany()
                .HasForeignKey(x => x.TipoActivoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Activo)
                .WithMany()
                .HasForeignKey(x => x.ActivoId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.Cantidad)
                .IsRequired().HasColumnType("integer");

            builder.Property(x => x.Operacion)
                .IsRequired();

            builder.Property(x => x.MontoTotal)
                .IsRequired().HasColumnType("decimal(18,4)");
        }
    }
}
