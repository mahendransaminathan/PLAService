using PLAService.Data;
using Microsoft.EntityFrameworkCore;
using PLAService.Providers;
using PLAService.PersonalServices;
using PLAService.CompanyServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(); // Registers controllers
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableDetailedErrors(builder.Configuration.GetValue<bool>("EntityFramework:EnableDetailedErrors"));
    options.EnableSensitiveDataLogging(builder.Configuration.GetValue<bool>("EntityFramework:EnableSensitiveDataLogging"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:3000",
                                        "http://localhost:4200",
                                        "https://productlicenseapproval-bsb3a3buh3bwavfy.northeurope-01.azurewebsites.net")  // Allow your frontend's URL

                          .AllowAnyHeader()                   // Allow all headers
                          .AllowAnyMethod()                   // Allow all methods (GET, POST, etc.)
                          .AllowCredentials());
});

builder.Services.AddScoped<IPersonalProvider, PersonalProvider>();
builder.Services.AddScoped<PersonalService>();

builder.Services.AddHttpClient<ICompanyServiceClient, CompanyServiceClient>(client =>
{
    client.BaseAddress = new Uri("https://companyservices.azurewebsites.net/");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.UseRouting();
// Use CORS policy globally
app.UseCors("AllowLocalhost");
app.MapControllers(); // Maps controller routes

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
