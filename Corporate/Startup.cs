using System.Text.Json;
using Corporate.Infrastructure.ServiceCollectionExtention;
using Corporate.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Corporate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceConfigs.ReegisterAllServices(services, Configuration);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            //using (var scope = scopeFactory.CreateScope())
            //{
            //    var dbInitializer = scope.ServiceProvider.GetService<IDbInitializerService>();
            //    dbInitializer.Initialize();
            //    dbInitializer.SeedData();
            //}
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //TODO:اینجا باید هندل کردن عمومی خطاها انجام بشه 
                //app.UseExceptionHandler(ex =>
                //{
                //    ex.Run(async context =>
                //    {
                //    context.Response.StatusCode = 500;
                //    context.Response.ContentType = "application/json";

                //    var error = context.Features.Get<IExceptionHandlerFeature>();
                //    if (error != null)
                //    {
                //        var ex = error.Error;

                //        await context.Response.WriteAsync(new ErrorModel()
                //        {
                //            StatusCode = 500,
                //            ErrorMessage = ex.Message
                //        }.ToString()); //ToString() is overridden to Serialize object
                //    });
                //});
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;
                    if (error?.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            State = 401,
                            Msg = "token expired"
                        }));
                    }
                    else if (error?.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            error=error
                            //State = 500,
                            //Msg = error.Error.Message,
                            //InnerException=error.Error.InnerException.Message
                        }));
                    }
                    else
                    {
                        await next();
                    }
                });
            });
            app.UseAuthentication();
            app.UseCors("http://localhost:4200");
            app.UseAuthorization();
            //app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "Admin",
                                pattern: "{area:exists}/{Controller=Home}/{action=Index}/{id?}");
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });
        }
    }
}
