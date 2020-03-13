using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {        
            ProductPictureMappings = new HashSet<ProductPictureMapping>();
            ProductCategoryMappings = new HashSet<ProductCategoryMapping>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int Order { get; set; }
        //public string Stock { get; set; }
        //public ICollection<TranslateEntity> Translates { get; set; }

        public ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }
        public ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; }

    }
}
