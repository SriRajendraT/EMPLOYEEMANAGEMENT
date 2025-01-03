using EMPLOYEEMANAGEMENT.DAL;
using EMPLOYEEMANAGEMENT.Repository.Classes;
using EMPLOYEEMANAGEMENT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Specialized;

namespace EMPLOYEEMANAGEMENT
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("dbNewSub"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("EMPAPI", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST");
                });
            });
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped<IBASICGETS, BASICGETS>();
            services.AddScoped<IEMPREPO, EMPREPO>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }
            app.UseCors("EMPAPI");
            
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMPAPI API v1");
            });
        }
    }
}
