using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder?.Property(x => x.EntityName).HasMaxLength(50);
            builder.Property(x => x.TagName).HasMaxLength(150);
        }
    }
}
