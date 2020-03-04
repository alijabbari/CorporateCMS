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
        public  void Configure(EntityTypeBuilder<ProductPictureMapping> builder)
        {
            builder?.HasKey(x => x.Id);
            builder.HasOne(productPicture => productPicture.Picture)
               .WithMany()
               .HasForeignKey(productPicture => productPicture.PictureId)
               .IsRequired();

            builder.HasOne(productPicture => productPicture.Product)
                .WithMany(product => product.ProductPictureMappings)
                .HasForeignKey(productPicture => productPicture.ProductId)
                .IsRequired();
        }
    }
}
