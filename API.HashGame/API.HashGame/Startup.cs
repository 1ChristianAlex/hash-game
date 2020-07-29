using API.HashGame.Data.Context;
using API.HashGame.Services.Profiles;
using API.HashGame.Services.Services;
using API.HashGame.Services.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void AddAsemblysToAutoMapper(IServiceCollection services)
        {
            services.AddSingleton(ConfigurarMapper());
        }

        private IMapper ConfigurarMapper()
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new HashGameProfile()));
            IMapper mapper = mappingConfig.CreateMapper();

            return mapper;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetValue<string>("ConnectionString:SqliteConnectionString");
            services.AddDbContext<HashGameContext>(options => options.UseSqlite(connection, b => b.MigrationsAssembly("API.HashGame")));
            AddAsemblysToAutoMapper(services);
            services.AddControllers();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPlayerService, PlayerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
