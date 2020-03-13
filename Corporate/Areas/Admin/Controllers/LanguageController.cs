using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Corporate.Domain.Entities;
using Corporate.Infrastructure;
using Corporate.Model.Dtoes;
using Corporate.Models;
using Corporate.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corporate.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAllLanguages(PageingDto pageingDto)
        {
            var pagedEntity = await _languageService.GetPagedAsync(pageingDto.CurrentPage, pageingDto.PageSize);
            if (pagedEntity != null)
            {
                var languageDto = _mapper.Map<PagedList<Language>, PagedList<LanguageDto>>(pagedEntity);
                return Ok(languageDto);
            }
            return new NoContentResult();
        }
        public async Task<IActionResult> AddLanguage(LanguageDto languageDto)
        {
            var entity = _mapper.Map<Language>(languageDto);
            var addedEntity = await _languageService.AddAsync(entity);
            if (addedEntity!=null)
            {
                return Ok(addedEntity);
            }
            return BadRequest();
        }
    }
}