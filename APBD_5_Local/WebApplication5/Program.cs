using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<TripsDBContext>(opt =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Default");
                opt.UseSqlServer(connectionString);
            }
        );

  
        builder.Services.AddScoped<IDbService, DbService>();
        var app = builder.Build();

       
   


        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        
        app.Run();
    }
}