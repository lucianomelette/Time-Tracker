using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Jalisco.TimeTracker.API.Domain.Repositories;
using Jalisco.TimeTracker.API.Domain.Services;
using Jalisco.TimeTracker.API.Persistance.Context;
using Jalisco.TimeTracker.API.Persistance.Repositories;
using Jalisco.TimeTracker.API.Services;
using Jalisco.TimeTracker.Models.Models.Auth;
using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using Jalisco.TimeTracker.Models.Models.Entidades;

namespace Jalisco.TimeTracker.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string _origins = "Servidor Amazon";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: _origins, builder =>
                {
                    builder.WithOrigins("https://develop.vendedores.jalisco365.com.ar", "https://vendedores.jalisco365.com.ar");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllers();

            services.AddAutoMapper(configuration => {}, typeof(Startup));
            services.AddScoped<ITimeTrackerTestsService, TimeTrackerTestsService>();
            services.AddScoped<ITimeTrackerTestsRepository, TimeTrackerTestsRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                ClockSkew = TimeSpan.Zero
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

        #if DEBUG
            app.UseCors(builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());
        #else
                app.UseCors(_origins);
        #endif

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
