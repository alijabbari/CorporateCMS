using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Infrastructure.FileHelper
{
    public static class DirectoryExtention
    {

        readonly static string Thumbs = @"Thums\\";
        readonly static string Upload = @"Upload\\";
        public static string ThumsPath(this IWebHostEnvironment webHostEnvironment)
        {
            return Path.Combine(webHostEnvironment.SubFilderPath(Upload),Thumbs);
        }
        public static string UploadPath(this IWebHostEnvironment webHostEnvironment)
        {
            return Path.Combine(webHostEnvironment.WebRootPath, Upload);
        }
        public static string SubFilderPath(this IWebHostEnvironment webHostEnvironment, string subFilder)
        {
            return Path.Combine(webHostEnvironment.WebRootPath, Upload,subFilder);
        }

        public static bool DirectoryExist(this IWebHostEnvironment webHostEnvironment, string directory)
        {
            return Directory.Exists(directory);
        }

        





    }
}
