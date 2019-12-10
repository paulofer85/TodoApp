using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp
{
    public class Startup
    {
        readonly string AllowMyOrigin = "_allowMyOrigin";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowMyOrigin,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                });
            }); 
            services.AddMvc();
            services.AddDbContext<TodoAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TodoAppContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(AllowMyOrigin);

            app.UseMvc();

            //app.Run(context =>
            //{
            //    return context.Response.WriteAsync("Hola Mundo!");
            //});
        }

        public void ConfigureHello(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hola Mundo!");
            });
        }
    }
}
