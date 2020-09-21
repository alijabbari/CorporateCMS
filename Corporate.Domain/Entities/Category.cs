using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {

            SubCategory = new HashSet<Category>();
            //ProductCategoryMappings = new HashSet<ProductCategoryMapping>();

        }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int Order { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public string Metakeword { get; set; }
        public string MetaDescription { get; set; }
        public int? PictureId { get; set; }
        //public Picture Picture { get; set; }
        public int? ParentId { get; set; }
        
        public Category Parent { get; set; }
        public ICollection<Category> SubCategory { get; set; }
        //public ICollection<NewsCategoryMapping> NewsCategoryMappings { get; set; }
        //public ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; }
    }
}
