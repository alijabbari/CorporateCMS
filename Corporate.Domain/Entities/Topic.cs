using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public ICollection<TranslateEntity> Translates { get; set; }
    }
}
