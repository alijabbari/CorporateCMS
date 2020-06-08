using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Model.Dtoes
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Order { get; set; }
    }
}
