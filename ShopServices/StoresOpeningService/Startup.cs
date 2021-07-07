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
            services.AddScoped<IShopsOpeningService, ShopsOpeningService>();
            services.AddScoped<IShopsInfoService, ShopsInfoService>();
            services.AddControllers();

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
