using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class Picture : BaseEntity
    {
        public string Src { get; set; }
        public string Alternate { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
        public string MimType { get; set; }
        public string SeoName { get; set; }
        public bool IsDefault { get; set; }
        public ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }
        //  public string Path { get; set; }
        //public Product Product { get; set; }
        //public Category Category { get; set; }
        //public News News { get; set; }  

        //TODO: This section implement when R&D in Hash image insert is deterministic
        //  public byte[] BineryData{ get; set; }h

    }
}
