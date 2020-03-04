using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class News : BaseEntity
    {
        public News()
        {
            NewsCategoryMappings = new HashSet<NewsCategoryMapping>();
        }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string SourceAddress { get; set; }
        public string SourceName { get; set; }
        public Picture Picture { get; set; }
        public ICollection<NewsCategoryMapping> NewsCategoryMappings { get; set; }
    }
}
