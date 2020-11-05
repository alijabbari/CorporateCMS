using Microsoft.AspNetCore.Http;

namespace Corporate.Model.Dtoes
{
    public class PictureDto
    {
        //public string Src { get; set; }
        public string Alternate { get; set; }
        public string Title { get; set; }
        //public int Size { get; set; }
        //public string MimType { get; set; }
        public string SeoName { get; set; }
        public bool IsDefault { get; set; }
        public IFormFile File { get; set; }
    }
}