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
    public class TipoActivoConfiguration : IEntityTypeConfiguration<TipoActivo>
    {

        public void Configure(EntityTypeBuilder<TipoActivo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
