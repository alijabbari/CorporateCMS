using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    public class ProductPictureMappingConfig : IEntityTypeConfiguration<ProductPictureMapping>
    {
        public void Configure(EntityTypeBuilder<ProductPictureMapping> builder)
        {
            builder?.HasKey(x => new { x.Id, x.ProductId, x.PictureId });
            builder.HasIndex(x => x.ProductId).HasName("IX_ProductPictureMapp_ProductId");
            builder.HasIndex(x => x.PictureId).HasName("IX_ProductPictureMapp_PictureId");
            builder.HasOne(productPicture => productPicture.Picture)
               .WithMany(x => x.ProductPictureMappings)
               .HasForeignKey(productPicture => productPicture.PictureId);

            builder.HasOne(productPicture => productPicture.Product)
                .WithMany(product => product.ProductPictureMappings)
                .HasForeignKey(productPicture => productPicture.ProductId);
        }
    }
}
