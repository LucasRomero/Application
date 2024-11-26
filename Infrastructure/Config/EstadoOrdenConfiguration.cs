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
    public class EstadoOrdenConfiguration: IEntityTypeConfiguration<EstadoOrden>
    {

        public void Configure(EntityTypeBuilder<EstadoOrden> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
