using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prey.DataAccess;
using Prey.Services;

namespace Prey.WebAPI
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();

            services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("PreyWebAPI", new OpenApiInfo()
                    {
                        Version = "1.0.0.0",
                        Title = "Prey WebAPI",
                        Description = "Prey WebAPI 描述文档",
                        Contact = new OpenApiContact()
                        {
                            Name = "Leon",
                            Email = "Leon.ID@qq.com",
                            Url = new Uri("https://github.com/CuteLeon/Prey"),
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "CuteLeon/Prey",
                            Url = new Uri("https://github.com/CuteLeon/Prey"),
                        },
                    });

                    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    options.IncludeXmlComments(
                        Path.Combine(
                            Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
                            "Prey.WebAPI.xml"));
                });

            services.AddMemoryCache();

            services.AddDbContext<DBContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlite(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
        }

        /// <summary>
        /// 配置 HTTP 请求管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/PreyWebAPI/swagger.json", "Prey WebAPI Document");
            });
        }
    }
}
