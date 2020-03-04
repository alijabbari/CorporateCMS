using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public DateTimeOffset? CreationDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public DateTimeOffset? EditeDateTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
