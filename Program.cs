using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Projeto_Nemo.Controllers.Middleware;
using Projeto_Nemo.Data;
using Projeto_Nemo.Repositories;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services;
using Projeto_Nemo.Services.Interfaces;
using System.Text;
using System.Text.Json.Serialization;

namespace Projeto_Nemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();
            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Nemo API",
                    Description = "Uma API Web em ASP.NET para gerenciar aquários",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Token JWT Header usando o esquema Bearer. Exemplo: `Bearer Token-JWT-Gerado`"
                }
                );

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<NemoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DataBase")));

            // Autenticação com Token JWT
            var chave = Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"]!);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(chave),
                };

                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var usuarioService = context.HttpContext.RequestServices.GetRequiredService<IUsuarioService>();
                        var claims = context.Principal!.Claims;
                        var claimId = claims.FirstOrDefault(c => c.Type == "id");

                        // Obter as informações do usuário do serviço de usuário
                        var user = usuarioService.RecuperarPorId(int.Parse(claimId?.Value ?? throw new InvalidOperationException()));

                        // Configurar o usuário no HttpContext
                        context.HttpContext.Items["User"] = user;

                        return Task.CompletedTask;
                    }
                };
            });

            // Repositories
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IAquarioRepository, AquarioRepository>();
            builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
            builder.Services.AddScoped<IParametroRepository, ParametroRepository>();
            builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();
            builder.Services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            builder.Services.AddScoped<IUsuarioAquarioRepository, UsuarioAquarioRepository>();

            // Services
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IAquarioService, AquarioService>();
            builder.Services.AddScoped<IParametroService, ParametroService>();
            builder.Services.AddScoped<IAlertaService, AlertaService>();
            builder.Services.AddScoped<IUsuarioAquarioService, UsuarioAquarioService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

            //app.UseHttpsRedirection();
            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}