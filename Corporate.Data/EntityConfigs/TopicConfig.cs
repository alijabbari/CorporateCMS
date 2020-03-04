using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    class TopicConfig : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(180).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(4000);
            builder.Property(x => x.Description).HasMaxLength(350);
            builder.Property(x => x.Link).HasMaxLength(400);
        }
    }
}
