using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class UserToken
    {
        public int Id { get; set; }
        public string AccessTokenHash { get; set; }
        public string RefreshTokenIdHash { get; set; }
        public string RefreshTokenIdHashSource { get; set; }
        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }

        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }

        public int UserId { get; set; } // one-to-one association
        public virtual User User { get; set; }
    }
}
