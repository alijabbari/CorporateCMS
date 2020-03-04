using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class NewsCategoryMapping
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int CategoryId { get; set; }
        public News News { get; set; }
        public Category Category { get; set; }
    }
}
