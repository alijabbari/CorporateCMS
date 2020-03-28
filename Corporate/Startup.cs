using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate.Data.Context;
using Corporate.Infrastructure.ServiceCollectionExtention;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //app.UseAuthorization();

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
