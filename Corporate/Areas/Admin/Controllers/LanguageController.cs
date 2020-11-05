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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Corporate.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Produces("application/json")]
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
        [HttpGet("Get")]
        public async Task<IActionResult> GetLanguageById([FromQuery]int id)
        {
            var entity = await _languageService.FindAsyncById(id);
            if (entity != null)
            {
                var dto = _mapper.Map<LanguageDto>(entity);
                return Ok(dto);
            }
            return NotFound();
        }
        [HttpGet("All")]

        public async Task<ActionResult> GetAllLanguages([FromQuery]PageingDto pageingDto)
        {

            var pagedLanguage = await _languageService.GetPagedAsync(pageingDto.CurrentPage, pageingDto.PageSize);
            if (pagedLanguage != null)
            {

                var languageDto = _mapper.Map<IEnumerable<LanguageDto>>(pagedLanguage);
                pageingDto.TotalPages = pagedLanguage.TotalPages;
                pageingDto.TotalCount = pagedLanguage.TotalCount;
                pageingDto.CurrentPage = pagedLanguage.CurrentPage;
                pageingDto.PageSize = pagedLanguage.PageSize;
                Response.PagingHeader("Pagination", pageingDto);
                return Ok(languageDto);
            }
            return new NoContentResult();
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddLanguage([FromBody]LanguageDto languageDto)
        {
            var entity = _mapper.Map<LanguageDto, Language>(languageDto);
            var addedEntity = await _languageService.AddAsync(entity);
            if (addedEntity != null)
            {
                return Ok(addedEntity);
            }
            return BadRequest();
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Update([FromBody]LanguageDto languageDto)
        {
            var entity = await _languageService.FindAsyncById(languageDto.Id);
            if (entity == null)
            {
                return NotFound("product for change not founded");
            }
            var updatedentity = _mapper.Map(languageDto, entity);
            await _languageService.UpdateAsync(updatedentity);
            return Ok(updatedentity);
        }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletItem = await _languageService.FindAsyncById(id);
            if (deletItem == null) return BadRequest();
            await _languageService.PhysicalDeleteAsync(deletItem);
            return Ok(200);
        }
    }
}