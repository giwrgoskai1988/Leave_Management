using LM.MVC.Contracts;
using LM.MVC.Services;
using LM.MVC.Services.Base;
using System.Reflection;

namespace LM.MVC
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
            //set api to start with iss express
            services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:44370"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ILeaveTypeService, LeaveTypeService>();

            services.AddSingleton<ILocalStorageService, LocalStorageService>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
