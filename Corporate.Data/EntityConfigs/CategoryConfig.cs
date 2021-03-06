﻿using Corporate.Domain.Entities;
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
            builder?.HasKey(x => x.Id);
            builder.HasIndex(x => x.ParentId).HasName("IX_ParentId");
            builder.HasIndex(x => x.Id).HasName("IX_CategoryId");
            builder.Property(x => x.PictureId).HasDefaultValue(0);
            builder.Property(x => x.Name).HasMaxLength(180).IsRequired();
            builder.Property(x => x.Metakeword).HasMaxLength(300).IsRequired(false);
            builder.Property(x => x.MetaDescription).HasMaxLength(300).IsRequired(false);
            builder.Property(x => x.ShortDescription).HasMaxLength(120).IsRequired(false);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTimeOffset.UtcNow);
            builder.Property(x => x.CreationDateTime).HasDefaultValue(DateTimeOffset.UtcNow);

            builder.HasMany(x => x.ProductCategoryMappings).WithOne(x => x.Categories).HasForeignKey(x => x.CategoryId);
            //builder.Property(x => x.ParentId).HasDefaultValue(0);



        }
    }
}
