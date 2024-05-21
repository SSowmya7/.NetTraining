
using AuthenticationPraction.Data;
using Microsoft.EntityFrameworkCore;
using AuthenticationPraction.Services;
using AuthenticationPraction.Contracts;
using Microsoft.Extensions.Configuration;
namespace AuthenticationPraction
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PrjContext>(opt => opt.UseSqlServer(
               builder.Configuration.GetConnectionString("dbcn")));
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<UserService,UserService>();

            var jwtSettings = builder.Configuration.GetSection("JWTSECRET");
            var secretKey = jwtSettings.GetValue<string>("+Key");

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
