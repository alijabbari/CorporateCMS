using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    public class ProductCategoryMappingConfig : IEntityTypeConfiguration<ProductCategoryMapping>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryMapping> builder)
        {
            builder?.HasKey(x => x.Id);            
            //builder.HasOne(x => x.Categories).WithMany(x => x.ProductCategoryMappings).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Products).WithMany(x => x.ProductCategoryMappings).HasForeignKey(x => x.ProductId);

        }
    }
}
