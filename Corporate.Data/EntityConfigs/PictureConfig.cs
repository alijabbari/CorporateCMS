using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder?.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).HasName("IX_PictureId");
            builder.Property(x => x.Alternate).HasMaxLength(50);
            builder.Property(x => x.SeoName).HasMaxLength(200);
            builder.Property(x => x.Src).HasMaxLength(200);
            builder.Property(x => x.Title).HasMaxLength(200);
            builder.Property(x => x.MimType).HasMaxLength(10);
        }
    }
}
