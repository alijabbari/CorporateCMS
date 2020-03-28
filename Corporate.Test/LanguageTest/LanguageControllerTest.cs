using Corporate.Areas.Admin.Controllers;
using Corporate.Models;
using Corporate.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Corporate.Test.LanguageTest
{

    public class LanguageControllerTest
    {
        LanguageController controller;

        public LanguageControllerTest()
        {

            var langservice = new Mock<ILanguageService>();
            langservice.Setup(service => service.FindAsyncById(1)).ReturnsAsync(new Domain.Entities.Language()
            {
                Culture = "fa-IR",
                Default = true,
                DisplayOrder = 1,
                Id = 1,
                Name = "persian",
                Rtl = true,
                SEOName = "fa"
            });
            var mapper = new Mock<IMapper>().Object;
             controller = new LanguageController(langservice.Object, mapper);
            //var paging = new PageingDto()
            //{
            //    CurrentPage = 1,
            //    PageSize = 1,
            //    TotalCount = 10,
            //    TotalPages = 10
            //};
        }
        [Fact]
        public async void GetLanguageReturnOk()
        {
            var result =await controller.GetLanguageById(1);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
