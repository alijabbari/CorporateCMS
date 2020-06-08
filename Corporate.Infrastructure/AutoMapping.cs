using AutoMapper;
using Corporate.Domain.Entities;
using Corporate.Model.Dtoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Infrastructure
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
