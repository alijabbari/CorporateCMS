using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Corporate.Data.EntityConfigs
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder?.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.RoleId);
            builder.HasOne(u => u.Roles).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
            builder.HasOne(u => u.Users).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
        }
    }
}
