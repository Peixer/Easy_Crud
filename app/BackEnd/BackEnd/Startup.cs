using AutoMapper;
using BackEnd.Data;
using BackEnd.Service;
using BackEnd.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BackEnd
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfiguration.Configure();

            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<CandidatoService, CandidatoService>();

            services.AddDbContext<CandidatoContext>(options =>
                options.UseSqlServer(Configuration["Data:ConnectionString"]));

            services.AddAutoMapper();

            services.AddCors();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            
            app.UseMvcWithDefaultRoute();
        }
    }
}
