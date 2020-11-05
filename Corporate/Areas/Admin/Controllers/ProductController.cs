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
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Corporate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        protected readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PagedList<ProductDto>> GetProducts(PageingDto pageingDto)
        {
            var prodctDto = await _productService.GetPagedAsync(pageingDto.CurrentPage,pageingDto.PageSize);
            var dto = _mapper.Map<PagedList<Product>, PagedList<ProductDto>>(prodctDto);
            return dto;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var findEntity = await _productService.FindAsyncById(id);
            var dto = _mapper.Map<ProductDto>(findEntity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProductDto productDto)
        {
            if (productDto is null)
            {
                return BadRequest("parameter most be not null");
            }
            var entity = _mapper.Map<Product>(productDto);
            await _productService.AddAsync(entity);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductDto productDto)
        {
            var entity = await _productService.FindAsyncById(productDto.Id);
            if (entity == null)
            {
                return NotFound("product for change not founded");

            }
            var updatedentity = _mapper.Map<ProductDto, Product>(productDto, entity);
            await _productService.UpdateAsync(updatedentity);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteEntity = await _productService.FindAsyncById(id);
            await _productService.PhysicalDeleteAsync(deleteEntity);
            return Ok();
        }
    }
}
