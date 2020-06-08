using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Data.EntityConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder?.Property(x => x.Username).HasMaxLength(450).IsRequired();
            builder?.HasIndex(x => x.Username).IsUnique();
            builder?.Property(x => x.Password).HasMaxLength(300).IsRequired();
            builder?.Property(x => x.SerialNumber).HasMaxLength(450);
            builder?.Property(x => x.DisplayName).HasMaxLength(450);
        }
    }
}
