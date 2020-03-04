using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class ProductPictureMapping
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
        public int DisplayOrder { get; set; }
    }
}
