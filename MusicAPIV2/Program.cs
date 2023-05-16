
using Microsoft.EntityFrameworkCore;
using MusicAPIV2.Configurations;
using MusicAPIV2.Contracts;
using MusicAPIV2.Data;
using MusicAPIV2.Models;
using MusicAPIV2.Repositories;
using System.Text.Json.Serialization;

namespace MusicAPIV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //This is for automapper
            builder.Services.AddAutoMapper(typeof(MapperConfig));

            //DbContext declaration with connection string
            builder.Services.AddDbContext<MusicDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cnn"));
            });

            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddScoped<ISongRepository, SongRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Use Cors
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}