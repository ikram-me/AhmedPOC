using ApiThree.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ApiThree
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

            // Singleton
            services.AddSingleton<IRadioRepository, RadioRepository>();
            services.AddSingleton<IInputRepository, InputRepository>();

            // Transient
            //services.AddTransient<ILog, FakeLog>();

            // Scoped
            //services.AddScoped<ILog, FakeLog>();
            string DB_CONNECTION_STRING = "host=postgres_image;port=5432;database=postgres;username=postgres;password=postgres";

            var connectionString = /*Environment.GetEnvironmentVariable("*/DB_CONNECTION_STRING/*")*/;
            services.AddDbContext<RadioDbContext>(options => options.UseNpgsql(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddDbContext<InputDbContext>(options => options.UseNpgsql(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddDbContext<AggDbContext>(options => options.UseNpgsql(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiTwo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiThree v1"));
            }
            else
            {
                app.UseHsts();
            }




            //   app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
