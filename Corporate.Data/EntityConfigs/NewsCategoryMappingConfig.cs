using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Corporate.Data.EntityConfigs
{
    class NewsCategoryMappingConfig : IEntityTypeConfiguration<NewsCategoryMapping>
    {
        public void Configure(EntityTypeBuilder<NewsCategoryMapping> builder)
        {
            //builder.HasOne(x => x.Category).WithMany(x => x.NewsCategoryMappings).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.News).WithMany(x => x.NewsCategoryMappings).HasForeignKey(x => x.NewsId);

        }
    }
}
