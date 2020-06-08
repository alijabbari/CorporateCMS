using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserTokens = new HashSet<UserToken>();
            UserRoles = new HashSet<UserRole>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        //public byte[] PasswordSalt { get; set; }
        //public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset? LastLoggedIn { get; set; }
        public string SerialNumber { get; set; }


        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }
    }
}
