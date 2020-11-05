using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Corporate.Data.EntityConfigs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder?.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).HasName("IX_ProductId");
            builder.HasIndex(x => x.Name).HasName("IX_ProductName");
            builder.Property(x => x.Name).HasMaxLength(85).IsRequired().IsConcurrencyToken(true);
            builder.Property(x => x.ShortDescription).HasMaxLength(210).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(4000).IsRequired(false);
            builder.HasMany(x => x.ProductPictureMappings).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(x => x.ProductCategoryMappings).WithOne(x => x.Products).HasForeignKey(x => x.ProductId);
        }
    }
}
