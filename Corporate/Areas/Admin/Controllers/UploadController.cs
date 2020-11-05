using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Corporate.Infrastructure.FileHelper;
using Corporate.Model.Dtoes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Corporate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IFileUploadService _fileService;

        public UploadController(IWebHostEnvironment hostingEnvironment, IFileUploadService fileUploadService)
        {
            _hostingEnvironment = hostingEnvironment;
            _fileService = fileUploadService;
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { dbPath });
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("file"), DisableRequestSizeLimit]
        public IActionResult FileUpload([FromForm] IList<IFormFile> file)
        {
            var content = _hostingEnvironment.WebRootPath;

            return Ok(content);
        }
        [HttpPost("pictureupload"), DisableRequestSizeLimit]
        public async Task<IActionResult> FileUpload([FromForm] PictureDto picture)
        {
            if (picture.File.Length == 0 || picture.File == null)
            {
                return BadRequest();
            }
            var thumb = _hostingEnvironment.SubFilderPath(@"Thums\");
            var upload = _hostingEnvironment.UploadPath();
            if (!_hostingEnvironment.DirectoryExist(upload) || !_hostingEnvironment.DirectoryExist(thumb))
            {
                return BadRequest();
            }
            var url = await _fileService.CreateThumbnail(picture.File, 250, 250, thumb, picture.Title);
            await _fileService.SaveImage(picture.File, 450, 450, upload, picture.Title);
            return Ok(url.Remove(0,_hostingEnvironment.WebRootPath.Length).Replace(@"\", "/").Insert(0,"~"));
        }
    }
}
