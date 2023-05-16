
using Microsoft.EntityFrameworkCore;
using MusicAPIV1.Configurations;
using MusicAPIV1.Data;
using MusicAPIV1.Services;
using System.Text.Json.Serialization;

namespace MusicAPIV1
{
    public class MusicService
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //The services for each Model Group- Song- Genre
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<ISongService, SongService>();
            builder.Services.AddScoped<IGenreService, GenreService>();

            //This is for automapper
            builder.Services.AddAutoMapper(typeof(MapperConfig));

            //DbContext declaration with connection string
            builder.Services.AddDbContext<MusicDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cnn"));
            });
            

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