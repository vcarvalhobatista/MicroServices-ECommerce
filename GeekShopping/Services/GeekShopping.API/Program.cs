
using GeekShopping.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var teste = builder.Configuration.GetConnectionString("Default");
            
            // Add services to the container.            
            builder.Services.AddDbContext<MySQLContext>(options => 
                                    options.UseMySql(builder.Configuration.GetConnectionString("Default"), 
                                    new MySqlServerVersion(new Version(8,0,34))));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
