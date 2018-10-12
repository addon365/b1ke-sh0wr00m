using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using swcApi;
using Threenine.Map;
using Api.Database;
using Api.Database.Entity.Threats;
using Swc.Service;
using Threenine.Data;
using Api.Domain.Bots;
using Threenine.Data.DependencyInjection;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using swcApi.Utils;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace swcApi
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

            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

            // Add framework services.
            services.AddDbContext<ApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString(Globals.api_database_connection_string_name)))
                .AddUnitOfWork<ApiContext>();
            services.AddTransient<IReferrerService, ReferrerService>();
            services.AddTransient<IEnquiriesService, EnquiriesService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductCompanyService, ProductCompanyService>();

            services.AddMvc();
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1,0);
            });
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //    new Info
            //    {
            //        Title = "Stop Web Crawlers API",
            //        Version = "v1",
            //        Description = "Stop Web Crawlers API to enable the update of Referer Spammer Lists",
            //        TermsOfService = "None",
            //        Contact = new Contact { Name = "addon technologies", Email = "tamilselvan@addon.cc", Url = "http://addon.cc" }
            //    });
            //    var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "api.xml");
            //    c.IncludeXmlComments(filePath);
            //}
            //);

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            //var appSettings = appSettingsSection.Get<AppSettings>();
            //TODO: Need to get secret from AppSettings.json
            //Refer :https://stackoverflow.com/questions/47032896/get-azure-appsettings-in-a-controller
            var key = Encoding.ASCII.GetBytes(AppSettings.SECRET);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();
            
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<ApiContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<ApiContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<ApiContext>().EnsureSeeded();
                }
               
            }

            //Set up code for automapper configuration 
           MapConfigurationFactory.Scan<Startup>();
           
           
        }
    }
}
