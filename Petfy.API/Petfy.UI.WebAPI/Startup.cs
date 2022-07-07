﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Petfy.Data;
using Petfy.Data.Models;
using Petfy.Data.Repositories;
using Petfy.Domain.Extensions;
using Petfy.Domain.Services;
using Petfy.UI.WebAPI.Middleware;
using System.Text;

namespace Petfy.UI.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddDbContext<PetfyDbContext>();
            
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppUser>>()
                .AddEntityFrameworkStores<PetfyDbContext>();
            
            services.AddScoped<ITokenService, TokenService>();
            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddScoped<IPetRepository, PetRepository>();

            services.AddScoped<IPetService, PetService>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200") );
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
