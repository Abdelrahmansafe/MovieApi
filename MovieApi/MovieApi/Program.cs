using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieApi.Model;
using MovieApi.Services;

namespace MovieApi

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

    builder.Services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(

  builder.Configuration.GetConnectionString("DefaultConnection")



                ));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddTransient<IGenerservices, GeneresServices>(); 
            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddControllers();  
            builder.Services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title="jjjajaj",
                    Contact=new OpenApiContact { Email="hhhh"}






                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
          Name="Authorization",
          Type=SecuritySchemeType.ApiKey,
          Scheme="Bearer",



                });





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