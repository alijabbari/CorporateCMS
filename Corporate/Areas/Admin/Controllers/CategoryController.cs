using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Corporate.Domain.Entities;
using Corporate.Infrastructure;
using Corporate.Infrastructure.CustomeApiRespone;
using Corporate.Infrastructure.CustomeApiResponse;
using Corporate.Model.Dtoes;
using Corporate.Models;
using Corporate.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Corporate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost("insert")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);
            if (category != null)
            {
                await _categoryService.AddAsync(category);
                return Ok(new OkApiResponse(categoryDto));
            }
            return BadRequest(new BadRequestApiResponse());
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.FindAsyncById(id);
            if (category == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }
        [HttpGet("list")]
        public async Task<IActionResult> List([FromBody] PageingDto pageingDto)
        {
            var pagedCategory = await _categoryService.GetPagedAsync(pageingDto.CurrentPage, pageingDto.PageSize);
            if (pagedCategory != null)
            {

                var categoryListDto = _mapper.Map<IEnumerable<CategoryDto>>(pagedCategory);
                var Pagination = _mapper.Map<PageingDto>(pagedCategory);
                Response.PagingHeader("Pagination", Pagination);
                return Ok(new OkApiResponse(categoryListDto));
            }
            return NotFound(new ApiResponse(404));

        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Update([FromBody] CategoryDto categoryDto)
        {
            var existCategory = await _categoryService.FindAsyncById(categoryDto.Id);
            if (existCategory != null)
            {
                var categoryMapped = _mapper.Map(categoryDto, existCategory);
                categoryMapped.EditeDateTime = DateTimeOffset.UtcNow;
                await _categoryService.UpdateAsync(categoryMapped);
                return Ok(new OkApiResponse(categoryDto));
            }
            return NotFound(new ApiResponse(404));
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var existCategory = await _categoryService.FindAsyncById(id);
            if (existCategory == null)
            {
                return NotFound(new ApiResponse(204));
            }
            var categoryMapped = _mapper.Map<Category>(existCategory);
            categoryMapped.IsDeleted = true;
            categoryMapped.DeletedDateTime = DateTimeOffset.UtcNow;
            await _categoryService.UpdateAsync(categoryMapped);

            return Ok(new ApiResponse(200));
        }
    }
}