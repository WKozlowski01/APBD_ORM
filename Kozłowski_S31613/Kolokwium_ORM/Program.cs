using Kolokwium_ORM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi




builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//zależnośći 
// builder.Services.AddScoped<IDbService, DbService>();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo
    {
        Title = "Kolokwium API",
        Version = "v1",
        Description = "Kolokwium API",
        Contact = new OpenApiContact
        {
            Name = "Kolokwium",
            Email = "kolokwium@gmail.com",
            Url = new Uri("https://www.example.com")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });   
});
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kolokwium");

    c.DocExpansion(DocExpansion.List);
    c.DefaultModelExpandDepth(0);
    c.DisplayRequestDuration();
    c.EnableDeepLinking();
});


app.UseHttpsRedirection();


app.MapControllers();



app.Run();
