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
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<CategoryDto>> AddCategory([FromBody] CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            if (category != null)
            {
                await _categoryService.AddAsync(category);
                return Ok(categoryDto);
            }
            return BadRequest();
        }
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.FindAsyncById(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }
        public async Task<ActionResult> GetList([FromQuery]PageingDto pageingDto)
        {
            var pagedCategory = await _categoryService.GetPagedAsync(pageingDto.CurrentPage, pageingDto.PageSize);
            if (pagedCategory != null)
            {

                var categoryListDto = _mapper.Map<IEnumerable<CategoryDto>>(pagedCategory);
                pageingDto.TotalPages = pagedCategory.TotalPages;
                pageingDto.TotalCount = pagedCategory.TotalCount;
                pageingDto.CurrentPage = pagedCategory.CurrentPage;
                pageingDto.PageSize = pagedCategory.PageSize;
                Response.PagingHeader("Pagination", pageingDto);
                return Ok(categoryListDto);
            }
            return new NoContentResult();

        }
    }
}