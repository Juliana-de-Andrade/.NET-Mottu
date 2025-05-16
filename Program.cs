
using challenger.Domain.Entities;
using challenger.Infrastructure.Context;
using challenger.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace challenger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration["Swagger:Title"],
                    Description = builder.Configuration["Swagger:Description"] + DateTime.Now.Year,
                    Contact = new OpenApiContact()
                    {
                        Email = "rm558550@fiap.com.br",
                        Name = "Victor Hugo"
                    }
                });
            });

            builder.Services.AddDbContext<CGContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
            });

            builder.Services.AddScoped<IRepository<Moto>, Repository<Moto>>(); // genérico, opcional se usar específico
            builder.Services.AddScoped<IMotoRepository, MotoRepository>();

            builder.Services.AddScoped<IRepository<Patio>, Repository<Patio>>();
            builder.Services.AddScoped<IPatioRepository, PatioRepository>();

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
