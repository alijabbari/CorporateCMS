using AutoMapper;
using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Infrastructure.Validation;
using Corporate.Services.IServices;
using Corporate.Services.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Infrastructure.ServiceCollectionExtention
{
    public static class ServiceConfigs
    {

        public static void ReegisterAllServices(IServiceCollection service, IConfiguration configuration)
        {
            service.AddMvc().AddFluentValidation();
            service.ConfigureCors();
            service.ConfigServicesDependencies();
            service.ConfigServiceDatabaseContext(configuration);
            service.ThirtPartyServices();
            service.JsonSetting();
            service.JWTAuthSecurityHandler(configuration);
            service.AddCustomOptions(configuration);
            service.RegisterValidatore();
        }

        #region Extentions

        public static void ConfigServicesDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<ILanguageService, LanguageService>();
            service.AddScoped<ICategoryService, CategoryService>();

            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            service.AddScoped<IUsersService, UsersService>();
            service.AddScoped<IRoleService, RoleService>();
            service.AddSingleton<ISecurityService, SecurityService>();
            service.AddScoped<IDbInitializerService, DbInitializerService>();
            service.AddScoped<ITokenStoreService, TokenStoreService>();
            service.AddScoped<ITokenValidatorService, TokenValidatorService>();
            service.AddScoped<ITokenFactoryService, TokenFactoryService>();
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
                options.AddPolicy("http://localhost:4200",
                    builder => builder.AllowAnyOrigin()
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

            });

        }
        /// <summary>
        /// register all fluent validatio 
        /// </summary>
        public static void RegisterValidatore(this IServiceCollection services)
        {
            services.AddTransient<IValidator<User>, UserValidation>();
        }
        public static void JsonSetting(this IServiceCollection services)
        {
            //services.AddControllers()
            services.AddControllers(options =>
            {
                // remove formatter that turns nulls into 204 - No Content responses
                // this formatter breaks SPA's Http response JSON parsing
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                options.OutputFormatters.Insert(0, new HttpNoContentOutputFormatter
                {
                    TreatNullValueAsNoContent = false
                });
            }).AddJsonOptions
            (
                options => options.JsonSerializerOptions.WriteIndented = true
            ).ConfigureApiBehaviorOptions(
                op => op.SuppressInferBindingSourcesForParameters = true
            );
        }

        public static void JWTAuthSecurityHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BearerTokenOption>(opts => configuration.GetSection("BearerTokens").Bind(opts));
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidIssuer = configuration["BearerTokens:Issuer"], // site that makes the token
                    ValidateIssuer = false, // TODO: change this to avoid forwarding attacks
                    ValidAudience = configuration["BearerTokens:Audience"], // site that consumes the token
                    ValidateAudience = false, // TODO: change this to avoid forwarding attacks
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["BearerTokens:Key"])),
                    ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                    ValidateLifetime = true, // validate the expiration
                    ClockSkew = TimeSpan.Zero // tolerance for the expiration date
                };
                cfg.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                        logger.LogError("Authentication failed.", context.Exception);
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                     {
                         var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                         logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);
                         return Task.CompletedTask;
                     },
                    OnForbidden = context =>
                     {
                         return Task.CompletedTask;

                     },
                    OnTokenValidated = context =>
                     {
                         var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
                         return tokenValidatorService.ValidateAsync(context);
                     },
                    OnMessageReceived = context =>
                     {
                         return Task.CompletedTask;
                     },
                };
            });
        }
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<BearerTokensOptions>()
                                .Bind(configuration.GetSection("BearerTokens"))
                                .Validate(bearerTokens =>
                                {
                                    return bearerTokens.AccessTokenExpirationMinutes < bearerTokens.RefreshTokenExpirationMinutes;
                                }, "RefreshTokenExpirationMinutes is less than AccessTokenExpirationMinutes. Obtaining new tokens using the refresh token should happen only if the access token has expired.");
            services.AddOptions<ApiSettings>()
                    .Bind(configuration.GetSection("ApiSettings"));
        }
        #endregion
    }
}
