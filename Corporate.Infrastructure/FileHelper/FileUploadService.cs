using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;

namespace Corporate.Infrastructure.FileHelper
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<string> CreateThumbnail(IFormFile formFile, int width, int height, string savePath, string name)
        {
            using var image = Image.Load(formFile.OpenReadStream());
            image.Mutate(x => x.Resize(width, height));
            var ext = Path.GetExtension(formFile.FileName);
            string saveFile = $"{savePath}{name}{ext}";
            await image.SaveAsync(saveFile);
            return saveFile;
        }
        public async Task<string> SaveImage(IFormFile formFile, int width, int height, string savePath, string name)
        {
            using var image = Image.Load(formFile.OpenReadStream());
            image.Mutate(x => x.Resize(width, height));
            var ext = Path.GetExtension(formFile.FileName);
            await image.SaveAsync($"{savePath}{name}{ext}");
            return savePath;
        }



    }
}
