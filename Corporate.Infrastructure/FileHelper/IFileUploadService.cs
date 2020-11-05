using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Infrastructure.FileHelper
{
    public interface IFileUploadService
    {
      Task<string> CreateThumbnail(IFormFile formFile,int width , int height,string savePath,string name);
      Task<string> SaveImage(IFormFile formFile,int width , int height,string savePath,string name);
    }
}
