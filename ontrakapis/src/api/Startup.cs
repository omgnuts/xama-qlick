using api.Data;
using api.Models;
using api.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.ResponseCompression;
using MySQL.Data.Entity.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace api
{
    /**
     * ASP.NET Core Reference: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
     */
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            {
                services.AddTransient<WaypointResource, WaypointResource>();
                services.AddTransient<NuanceResource, NuanceResource>();

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseMySQL(Configuration.GetConnectionString("DataSource:MySQLProvider"));
                });
            }

            {
                // Enable CORS
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });

                    options.AddPolicy("AllowSpecificOrigin",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:18080")
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });

                    /*
                     * Example below of finer granularity
                     */
                    //options.AddPolicy("AllowSpecificOrigin",
                    //    builder =>
                    //    {
                    //        builder.WithOrigins("http://localhost:18080")
                    //               .WithMethods("GET", "POST")
                    //               .AllowAnyHeader();
                    //    });

                });
                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllOrigins"));
                });
            }

            {
                services.AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                });
                services.Configure<GzipCompressionProviderOptions>(options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });
            }

            {
                //services.AddRouting();
                services.AddMvc();

                // return JSON response in form of Camel Case so that we can sure consume the API in any client.
                // Enable CamelCasePropertyNamesContractResolver in Configure Services.
                //services.Configure<MvcJsonOptions>(options =>
                //{
                //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //});

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, DataContext context)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseCors("AllowAllOrigins");

            app.UseResponseCompression();

            // Perform the routing
            //app.UseRouter(CreateRoutes(app).Build());
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/v1/{controller}/{action}/{id?}");
            });

            // Mock InitializeMockData the DB
            MockDataInitialiser.InitializeMockData(context);
            context.Database.EnsureCreated();

        }

        RouteBuilder CreateRoutes(IApplicationBuilder app)
        {
            RouteHandler defaultHandler = new RouteHandler(context =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync(
                    $"Strapping Route values: {string.Join(", ", routeValues)}");
            });

            RouteBuilder routeBuilder = new RouteBuilder(app, defaultHandler);

            routeBuilder.MapRoute(
                "Track Default Route",
                "api/v1/{action:regex(^track|create|detonate$)}/{id:int}");

            routeBuilder.MapRoute("readme/{name}", context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Hi, {name}!");
            });

            return routeBuilder;
        }
    }

}
