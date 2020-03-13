using AutoMapper;
using Corporate.Data.Context;
using Corporate.Services.IServices;
using Corporate.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Infrastructure.ServiceCollectionExtention
{
    public static class ServiceConfigs
    {

        public static void ReegisterAllServices(IServiceCollection service , IConfiguration configuration)
        {
            ConfigServiceDatabaseContext(service, configuration);
            ConfigServicesDependencies(service);
            ThirtPartyServices(service);
        }
        public static void ConfigServicesDependencies(IServiceCollection service)
        {
            service.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ICategoryService, CategoryService>();            
        }
        public static void ConfigServiceDatabaseContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CorporateDb>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultCnn")));

        }
        public static void ThirtPartyServices(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(Startup));
        }
        
    }
}
