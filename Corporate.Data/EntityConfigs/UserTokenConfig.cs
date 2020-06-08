using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corporate.Data.EntityConfigs
{
    class UserTokenConfig : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasOne(x => x.User).WithMany(ut => ut.UserTokens).HasForeignKey(f => f.UserId);
            builder?.Property(x => x.RefreshTokenIdHash).HasMaxLength(450).IsRequired();
            builder?.Property(x => x.RefreshTokenIdHashSource).HasMaxLength(450);

        }
    }
}
