using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Three.Services;
using ThreeApi.Repositories;

namespace ThreeApi
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
                //.AddXmlSerializerFormatters();  //xml format
            services.AddSingleton<IClock, UtcClock>();
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<ISummaryRepository, SummaryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
