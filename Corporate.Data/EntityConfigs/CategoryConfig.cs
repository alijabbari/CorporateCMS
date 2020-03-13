using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Data.EntityConfigs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder?.Property(x => x.Name).HasMaxLength(180).IsRequired();
            builder.Property(x => x.Metakeword).HasMaxLength(300).IsRequired(false);
            builder.Property(x => x.MetaDescription).HasMaxLength(300).IsRequired(false);
            builder.Property(x => x.ShortDescription).HasMaxLength(120).IsRequired(false);
            builder.HasMany(x => x.ParentCategory).WithOne().HasForeignKey(x => x.ParentId).IsRequired(false);
            builder.Property(x => x.ParentId).HasDefaultValue(0);
        }
    }
}
