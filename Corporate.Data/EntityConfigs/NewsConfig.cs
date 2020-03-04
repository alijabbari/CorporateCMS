using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(120).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.Property(x => x.SourceAddress).HasMaxLength(400);
            builder.Property(x => x.SourceName).HasMaxLength(100);
        }
    }
}
