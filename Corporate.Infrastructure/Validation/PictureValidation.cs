using Corporate.Domain.Entities;
using Corporate.Model.Dtoes;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Corporate.Infrastructure.FileHelper;

namespace Corporate.Infrastructure.Validation
{
    public class PictureValidation : AbstractValidator<PictureDto>
    {
        public PictureValidation()
        {
            RuleFor(pi => pi.Title).MaximumLength(150).MinimumLength(4).WithMessage("عنوان تصویر باید حداقل ۴ و حداکثر ۱۵۰ کاراکتر باشد");
            RuleFor(pi => pi.Alternate).MaximumLength(80).MinimumLength(0).WithMessage("عنوان تصویر باید حداکثر ۸۰ کاراکتر باشد");
            RuleFor(pi => pi.SeoName).MaximumLength(300).MinimumLength(0).WithMessage("عنوان تصویر باید حداکثر ۳۰۰ کاراکتر باشد");
            RuleFor(pi => pi.File).NotNull().WithMessage("تصویری را انتخاب نمایید").DependentRules(() =>
            {
                RuleFor(pi => pi.File).Must(file => HasValidImageExtention(file?.ContentType, file?.FileName)).When(x => x.File != null)
                .WithMessage(x => $"نوع پسوند فایل ارسالی پشتیبانی نمی شود. {Environment.NewLine} نام" +
                $"  :{Path.GetFileNameWithoutExtension(x.File.FileName)} {Environment.NewLine} پسوند : {Path.GetExtension(x.File.FileName)}");
                RuleFor(pi => pi.File).Must(pi => IsValidFileNameChars(pi.FileName))
                .WithMessage("نام فایل نیاید شامل کاراکتر های  غیر مجاز باشد");
            });


        }

        private static bool IsValidFileNameChars(string fileName)
        {
            char[] invalidFileChars = Path.GetInvalidFileNameChars();
            var charFileName = Path.GetFileNameWithoutExtension(fileName);
            foreach (var ch in invalidFileChars.
                SelectMany(item => charFileName.Where(charName => charName == item).Select(charName => new { })))
            {
                return false;
            }

            return true;
        }

        private static bool HasValidImageExtention(string contentType, string fileName)
        {
            var ext = Path.GetExtension(fileName)?.ToLowerInvariant();
            return (contentType.ToLowerInvariant(), ext) switch
            {
                (MimeTypes.ImageApng, ".apng") => true,
                (MimeTypes.ImageJpeg, ".jpg") => true,
                (MimeTypes.ImageJpeg, ".jpeg") => true,
                (MimeTypes.ImageJpeg, ".pjpeg") => true,
                (MimeTypes.ImageJpeg, ".pjp") => true,
                (MimeTypes.ImageBmp, ".bmp") => true,
                (MimeTypes.ImageGif, ".gif") => true,
                (MimeTypes.ImageXicon, ".ico") => true,
                (MimeTypes.ImageXicon, ".cur") => true,
                (MimeTypes.ImagePng, ".png") => true,
                (MimeTypes.ImageSvgXml, ".svg") => true,
                (MimeTypes.ImageWebp, ".webp") => true,
                _ => false,
            };
        }
    }
}
