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

        public static void ReegisterAllServices(IServiceCollection service, IConfiguration configuration)
        {
            service.ConfigureCors();
            service.ConfigServicesDependencies();
            service.ConfigServiceDatabaseContext(configuration);
            service.ThirtPartyServices();
            service.JsonSetting();
        }

        #region Extentions

        public static void ConfigServicesDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ILanguageService, LanguageService>();
            service.AddScoped<ICategoryService, CategoryService>();
        }
        public static void ConfigServiceDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CorporateDb>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultCnn")));

        }
        public static void ThirtPartyServices(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            service.AddSingleton(mapper);
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            });

        }
        public static void JsonSetting(this IServiceCollection services)
        {
            services.AddControllers()
        .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true).ConfigureApiBehaviorOptions(op=>op.SuppressInferBindingSourcesForParameters=true);
        }

        #endregion
    }
}
