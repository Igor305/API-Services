using AutoMapper;
using BusinessLogicLayer.AutoHelper;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.EFRepositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace PresentationLayer
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
            services.AddDbContext<ShopsContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:SQL26-Shops"]));
            services.AddDbContext<_1cExchangeContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:SQL26-1cExchange"]));

            services.AddScoped<IShopsRepository, ShopsRepository>();
            services.AddScoped<IRegionsLocalizationRepository, RegionsLocalizationRepository>();
            services.AddScoped<IDistrictsLocalizationRepository, DistrictsLocalizationRepository>();
            services.AddScoped<ICitiesLocalizationRepository, CitiesLocalizationRepository>();
            services.AddScoped<IStreetsLocalizationRepository, StreetsLocalizationRepository>();
            services.AddScoped<IShopRegionLocalizationRepository, ShopRegionLocalizationRepository>();
            services.AddScoped<IEmployeesDirectoryRepository, EmployeesDirectoryRepository>();
            services.AddScoped<IShopWorkTimesRepository, ShopWorkTimesRepository>();
            services.AddScoped<IShopsOpeningService, ShopsOpeningService>();
            services.AddScoped<IShopsInfoService, ShopsInfoService>();
            services.AddScoped<IShopsToTMSService, ShopsToTMSService>();

            services.AddHostedService<TimedHostedService>();
            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "ShopServices API",
                    Description = "Колекція сервісів зв’язаних з Shops-ом",
                    Contact = new OpenApiContact
                    {
                        Name = "the developer",
                        Email = "i.talavyria@avrora.ua"
                    },
                });

                // Set the comments path for the Swagger JSON and UI.

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var xmlPath2 = Path.Combine(AppContext.BaseDirectory, @"BusinessLogicLayer.xml");

                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(xmlPath2);
            });

            MapperConfiguration mapperconfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            IMapper mapper = mapperconfig.CreateMapper();
            services.AddSingleton(mapper);

        }     

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopServices API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}