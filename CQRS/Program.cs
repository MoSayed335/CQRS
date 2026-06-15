
using CQRS_Lib;
using CQRS_Lib.DataAccess;
using CQRS_Lib.Models;
using CQRS_Lib.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace CQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(d => d.UseSqlServer
            (builder.Configuration.GetConnectionString("MyDataBase")));
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IRepository<item>, Repository<item>>();
            builder.Services.AddMediatR(typeof(Class1).Assembly);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
