using System.Collections.Generic;

namespace Corporate.Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User Users { get; set; }
        public virtual Role Roles { get; set; }
    }
}