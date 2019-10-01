using addon365.Database;
using addon365.Database.Service;
using addon365.Database.Service.Accounts;
using addon365.Database.Service.Chit;
using addon365.Database.Service.Crm;
using addon365.Database.Service.Crm.Address;
using addon365.Database.Service.Inventory;
using addon365.Database.Service.Permission;
using addon365.Database.Service.pos;
using addon365.Database.Service.Report;
using addon365.Database.Service.Sales;
using addon365.IService;
using addon365.IService.Accounts;
using addon365.IService.Chit;
using addon365.IService.Crm;
using addon365.IService.Crm.Address;
using addon365.IService.Inventory;
using addon365.IService.Permission;
using addon365.IService.pos;
using addon365.IService.Sales;
using addon365.Web.API.Utils;
using addon365.Web.API.Utils.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Threenine.Data.DependencyInjection;
using Threenine.Map;

namespace addon365.Web.API
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
            services.AddCors();
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

            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IInquiryReportService, InquiryReportService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<ISchemeService, SchemeService>();
            services.AddTransient<ISubscribeService, SubscribeService>();
            services.AddTransient<IChitDueService, ChitDueService>();
            services.AddTransient<IVoucherTypeService, VoucherTypeService>();
            services.AddTransient<IAccountBookService, AccountBookService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<ISellerService, SellerService>();
            services.AddTransient<IBuyerService, BuyerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            #region Point Of Sale
            services.AddTransient<ICatelogItemService, CatelogItemService>();
            services.AddTransient<ICategoryService, CatelogCategoryService>();
            services.AddTransient<ICatelogBrandService, CatelogBrandService>();
            #endregion

            #region CRM Services are here.

            #region Address Services goes here
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<ISubDistrictService, SubDistrictService>();
            services.AddTransient<ILocalityService, LocalityService>();
            services.AddTransient<IPincodeService, PincodeService>();
            #endregion



            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IAppointmentStatusService, AppointmentStatusService>();
            services.AddTransient<IStatusMasterService, StatusMasterService>();
            services.AddTransient<IBusinessCustomerService, BusinessCustomerService>();
            services.AddTransient<ILeadService, LeadService>();
            services.AddTransient<ILeadSourceService, LeadSourceService>();
            services.AddTransient<ILeadStatusService, LeadStatusService>();

            services.AddTransient<IRoleGroupService, RoleGroupService>();

            services.AddTransient<ICampaignService, CampaignService>();

            #endregion
            services.AddScoped<RequestInfo>();
            services.AddControllers();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //    .AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver =
            //        new CamelCasePropertyNamesContractResolver();
            //}); ;
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "My API",
            //        Description = "My First ASP.NET Core Web API",
            //        TermsOfService = "None",
            //        Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@addon.cc", Url = "www.addon.cc" }
            //    });
            //});
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
            app.UseCors(
                    options => options
                    .WithOrigins("http://localhost:4200",
                    "https://addon365crm.azurewebsites.net")
                    .AllowAnyMethod().AllowAnyHeader()

                    );
            var defaultCulture = new CultureInfo("en-IN");
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHealthChecks("/health");
                endpoints.MapControllerRoute("default",
                    "{controller}/{action}/{id?}",
                    new { controller = "echo" }
                );
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});
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
                var apicon = serviceScope.ServiceProvider.GetService<ApiContext>();
                if (!apicon.AllMigrationsApplied())
                {


                    apicon.Database.Migrate();
                    var UserService = serviceScope.ServiceProvider.GetService<IUserService>();
                    if (!apicon.Users.Any())
                    {
                        UserService.InsertUser(new addon365.Database.Entity.Users.User() { UserId = "user1", Password = "pass1", UserName = "user1" });
                    }
                    apicon.EnsureSeeded();
                }

            }

            //Set up code for automapper configuration
            MapConfigurationFactory.Scan<Startup>();


        }
    }
}
