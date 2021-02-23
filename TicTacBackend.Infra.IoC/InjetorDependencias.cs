using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TicTacBackend.Domain.Repositories;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Services.Auth;
using TicTacBackend.Domain.Services.Interfaces.Auth;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories;
using TicTacBackend.Infra.Data.Repositories.Base;
using TicTacBackend.Infra.Helpers.JwtHelpers;
using TicTacBackend.Infra.Helpers.JwtHelpers.Interfaces;

namespace TicTacBackend.Infra.IoC
{
    public static class InjetorDependencias
    {
        public static void ConfigurarDependencias(IServiceCollection services, IConfiguration configuration)
        {
            ConfigurarJwt(services, configuration);
            ConfigurarDatabases(services, configuration);
            ConfigurarAppServices(services);
            ConfigurarServices(services);
            ConfigurarRepositories(services);
        }

        private static void ConfigurarRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        private static void ConfigurarServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtHelper, JwtHelper>();
        }

        private static void ConfigurarAppServices(IServiceCollection services)
        {
        }

        private static void ConfigurarDatabases(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        }

        private static void ConfigurarJwt(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
