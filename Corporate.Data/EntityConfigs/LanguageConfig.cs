using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Culture).HasMaxLength(6).IsRequired();
            builder.Property(l => l.Name).HasMaxLength(45).IsRequired();
            builder.Property(l => l.SEOName).HasMaxLength(6).IsRequired(false);
        }
    }
}
