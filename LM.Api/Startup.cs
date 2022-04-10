using LM.Application;
using LM.Infrastructure;
using LM.Persistence;
using Microsoft.OpenApi.Models;

namespace LM.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplicationServices();
            services.ConfigureInfrastructureServices(Configuration);
            services.ConfigurePersistenceServices(Configuration);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LM.Api", Version = "v1" });
            });

            services.AddCors(c =>
            {
                c.AddPolicy("MyPolicy",
                    builder => builder.AllowAnyOrigin()
                                       .AllowAnyHeader()
                                       .AllowAnyMethod());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LM.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
