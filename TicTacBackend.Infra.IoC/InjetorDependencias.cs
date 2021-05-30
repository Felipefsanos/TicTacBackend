using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TicTacBackend.Application.AppServices;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.AutoMapper;
using TicTacBackend.Domain.Repositories;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Cliente;
using TicTacBackend.Domain.Repositories.Orcamentos;
using TicTacBackend.Domain.Repositories.Prestadores;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Domain.Repositories.Servicos;
using TicTacBackend.Domain.Services.Auth;
using TicTacBackend.Domain.Services.Clientes;
using TicTacBackend.Domain.Services.Email;
using TicTacBackend.Domain.Services.Interfaces.Auth;
using TicTacBackend.Domain.Services.Interfaces.Clientes;
using TicTacBackend.Domain.Services.Interfaces.Email;
using TicTacBackend.Domain.Services.Interfaces.Orcamentos;
using TicTacBackend.Domain.Services.Interfaces.Prestadores;
using TicTacBackend.Domain.Services.Interfaces.Produtos;
using TicTacBackend.Domain.Services.Interfaces.Servicos;
using TicTacBackend.Domain.Services.Orcamentos;
using TicTacBackend.Domain.Services.Prestadores;
using TicTacBackend.Domain.Services.Produtos;
using TicTacBackend.Domain.Services.Servicos;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories;
using TicTacBackend.Infra.Data.Repositories.Base;
using TicTacBackend.Infra.Data.Repositories.Clientes;
using TicTacBackend.Infra.Data.Repositories.Orcamentos;
using TicTacBackend.Infra.Data.Repositories.Prestadores;
using TicTacBackend.Infra.Data.Repositories.Produtos;
using TicTacBackend.Infra.Data.Repositories.Servicos;
using TicTacBackend.Infra.Helpers.JwtHelpers;
using TicTacBackend.Infra.Helpers.JwtHelpers.Interfaces;

namespace TicTacBackend.Infra.IoC
{
    public static class InjetorDependencias
    {
        public static void ConfigurarDependencias(IServiceCollection services, IConfiguration configuration)
        {
            ConfigurarAutoMapper(services);
            ConfigurarJwt(services, configuration);
            ConfigurarDatabases(services, configuration);
            ConfigurarAppServices(services);
            ConfigurarServices(services);
            ConfigurarRepositories(services);
        }

        private static void ConfigurarAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(config => AutoMapperConfig.MapperConfig(config));
        }

        private static void ConfigurarRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICanalCaptacaoRepository, CanalCaptacaoRepository>();
            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IComponenteRepository, ComponenteRepository>();
            services.AddScoped<IPrestadorRepository, PrestadorRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
        }

        private static void ConfigurarServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IComponenteService, ComponenteService>();
            services.AddScoped<IPrestadorService, PrestadorService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        private static void ConfigurarAppServices(IServiceCollection services)
        {
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IOrcamentoAppService, OrcamentoAppService>();
            services.AddScoped<ICanalCaptacaoAppService, CanalCaptacaoAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IComponenteAppService, ComponenteAppService>();
            services.AddScoped<IPrestadorAppService, PrestadorAppService>();
            services.AddScoped<IServicoAppService, ServicoAppService>();
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
