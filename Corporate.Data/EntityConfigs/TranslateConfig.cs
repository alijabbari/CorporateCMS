using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Corporate.Domain.Entities;
namespace Corporate.Data.EntityConfigs
{
    public class TranslateConfig : IEntityTypeConfiguration<TranslateEntity>
    {
        public void Configure(EntityTypeBuilder<TranslateEntity> builder)
        {
            builder?.HasKey(x => x.Id);
            builder.Property(x => x.EntityIdentify).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.LanguageId).IsRequired(false);
            builder.Property(x => x.EntityId).IsRequired(false);
            builder.Property(x => x.TranslateKey).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.TranslateValue).HasMaxLength(250).IsRequired(false);

        }
    }
}
