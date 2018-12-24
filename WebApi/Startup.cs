using System;
using System.IO;
using System.Reflection;
using UniversalForm.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using UniversalForm.Domain.IRepositories;
using UniversalForm.EF.Repositories;

namespace WebApi
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
            //配置信息
            var settingConfigSection = Configuration.GetSection("AppSettings");
            //获取数据库字符串
            var sqlConnectionString = Configuration.GetConnectionString("SQLServer");

            //添加数据上下文
            services.AddDbContext<EFDBContext>(options => options.UseSqlServer(sqlConnectionString,b => b.UseRowNumberForPaging()));

            //依赖注入
            services.AddScoped<IFormRepository, FormRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Session服务
            services.AddSession();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.0.0",
                    Title = $"UniversalForm API",
                    Description = "UniversalForm API",
                    TermsOfService = "Leoxuan",
                    Contact = new Contact
                    {
                        Name = "Leoxuan",
                        Email = "xuanaijun1991@outlook.com"
                    },
                    License = new License
                    {
                        Name = "Leoxuan",
                        Url = "https://www.cnblogs.com/leoxuan/"
                    }
                });

                // 从xml读注释信息.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //访问静态文件
            app.UseStaticFiles();

            //使用Session
            app.UseSession();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversalForm");
            });

            app.UseHttpsRedirection();
            app.UseMvc();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default2",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
