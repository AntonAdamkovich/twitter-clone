using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TwitterClone.Services.AuthService;

namespace TwitterClone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            
            // services
            //     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options =>
            //     {
            // options.Authority = Configuration.GetValue<string>("Auth0:Authority");
            //         options.Audience = Configuration.GetValue<string>("Auth0:Audience");
            //         
            //         // options.TokenValidationParameters = new TokenValidationParameters
            //         // {
            //         //     NameClaimType = ClaimTypes.NameIdentifier
            //         // };
            //     });
            
            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
            // });

            services.AddScoped<IAuthService, AuthService>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
