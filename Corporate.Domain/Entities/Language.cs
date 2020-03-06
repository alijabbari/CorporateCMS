using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class Language :BaseEntity
    {
        public int Id { get; set; }
        public string Culture { get; set; }
        public bool Rtl { get; set; }
        public string Name { get; set; }
        public bool Default { get; set; }
        public string SEOName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
