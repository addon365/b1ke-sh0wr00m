using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Threenine.Map;
using Api.Database;
using Swc.Service;
using Threenine.Data.DependencyInjection;
using swcApi.Utils;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swc.Service.Sales;
using Swc.Service.Crm;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Swc.Service.Report;
using swcApi.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json.Serialization;
using Swc.Service.Chit;

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

            services.AddScoped<IUrlHelper>(factory =>

            {

                var actionContext = factory.GetService<IActionContextAccessor>()

                                           .ActionContext;

                return new UrlHelper(actionContext);

            });


            services.AddTransient<IReferrerService, ReferrerService>();
            services.AddTransient<IEnquiriesService, EnquiryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductCompanyService, ProductCompanyService>();
            services.AddTransient<IEnquiryTypeService, EnquiryTypeService>();
            services.AddTransient<IZonalService, ZonalService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILicenseService, LicenseService>();
            services.AddTransient<IAccessoriesService, AccessoriesService>();
            services.AddTransient<ISalesService, SalesService>();
            services.AddTransient<IFollowUpService, FollowUpService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IInquiryReportService, InquiryReportService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<ISchemeService, SchemeService>();
            services.AddScoped<RequestInfo>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>

            {

                options.SerializerSettings.ContractResolver =

                    new CamelCasePropertyNamesContractResolver();

            }); ;

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


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

            services.Configure<RouteOptions>(options =>
            options.ConstraintMap.Add("license", typeof(LicenseRouteConstraint)));

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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            //https://stackoverflow.com/questions/38298312/dynamic-routing-in-asp-net-core

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSpaStaticFiles();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default",
                    "{controller}/{action}/{id?}",
                    new { controller = "echo" }
                );
            });


            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

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
