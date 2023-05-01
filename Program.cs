using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projeto_Nemo.Data;
using Projeto_Nemo.Repositories;
using Projeto_Nemo.Repositories.Interfaces;
using Projeto_Nemo.Services;
using Projeto_Nemo.Services.Interfaces;

namespace Projeto_Nemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
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
            });

            builder.Services.AddDbContext<NemoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            // Repositories
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IAquarioRepository, AquarioRepository>();

            // Services
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IAquarioService, AquarioService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
