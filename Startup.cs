using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using OEEWebAPI.Utilities.Swagger;
using OEEWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Repository;

namespace OEEWebAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;
        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Entity Framework database connection
            services.AddDbContext<OEEContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OeeDbConnection")));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add CORS
            services.AddCors();

            // Add MVC
            services.AddMvc();

            // Add Swagger Generator
            services.AddSwaggerGen(c =>
            {
                c.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "OEE Web API",
                    Description = "OEE Web API Data Services",
                    TermsOfService = "Some terms ..."
                });

                c.OperationFilter<AssignOperationVendorExtensions>();
            });

            if (_hostingEnv.IsDevelopment())
            {
                services.ConfigureSwaggerGen(c =>
                {
                    c.IncludeXmlComments(GetXmlCommentsPath(PlatformServices.Default.Application));
                });
            }

            // Register the OEE repositories with Dependency Injection (DI) container as Singleton
            // Primary repositories
            services.AddTransient<IAvailabilityRepository, AvailabilityRepository>();
            services.AddTransient<IEquipmentFailureRepository, EquipmentFailureRepository>();
            services.AddTransient<IIdlingMinorStoppageRepository, IdlingMinorStoppageRepository>();
            services.AddTransient<IPerformanceEfficiencyRepository, PerformanceEfficiencyRepository>();
            services.AddTransient<IPlannedRepository, PlannedRepository>();
            services.AddTransient<ISetupAdjustmentRepository, SetupAdjustmentRepository>();
            services.AddTransient<IUnPlannedRepository, UnPlannedRepository>();
            //Dependent Repositories
            services.AddTransient<IOEERepository, OEERepository>();
            services.AddTransient<ICalibrationAlignmentRepository, CalibrationAlignmentRepository>();
            services.AddTransient<ICartMHERepository, CartMHERepository>();
            services.AddTransient<IConstraintsRepository, ConstraintsRepository>();
            services.AddTransient<IITRepository, ITRepository>();
            services.AddTransient<ILoadUnloadRepository, LoadUnloadRepository>();
            services.AddTransient<IMachineRepository, MachineRepository>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IMinorStopRepository, MinorStopRepository>();
            services.AddTransient<INCProgrammingRepository, NCProgrammingRepository>();
            services.AddTransient<IPersonalPlannedRepository, PersonalPlannedRepository>();
            services.AddTransient<IPersonalUnplannedRepository, PersonalUnplannedRepository>();
            services.AddTransient<IPlannedDowntimeRepository, PlannedDowntimeRepository>();
            services.AddTransient<IPMPlannedMaintenanceRepository, PMPlannedMaintenanceRepository>();
            services.AddTransient<IReducedSpeedRespository, ReducedSpeedRepository>();
            // Dashboard Repository
            services.AddTransient<IDashboardRepository, DashboardRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            // Use CORS
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
                
            });

            app.UseMvc();

            // Make wwwroot in app servable
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
            //if (_hostingEnv.IsDevelopment())
            //{
            //    app.UseSwaggerUi(swaggerUrl: "/swagger/v1/swagger.json");
            //}
            //else
            //{
            //    app.UseSwaggerUi(swaggerUrl: "/OEEWebAPI/swagger/v1/swagger.json");
            //}

        }

        private string GetXmlCommentsPath(ApplicationEnvironment appEnvironment)
        {
            return Path.Combine(appEnvironment.ApplicationBasePath, "OEEWebAPI.xml");
        }

    }
}
