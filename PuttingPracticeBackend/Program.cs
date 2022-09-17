using Microsoft.EntityFrameworkCore;
using PuttingPracticeBackend.Authorization;
using PuttingPracticeBackend.Data;
using PuttingPracticeBackend.Helpers;
using PuttingPracticeBackend.Interfaces;
using PuttingPracticeBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var env = builder.Environment;
services.AddDbContext<PuttingPracticeDataContext>();
services.AddCors();
services.AddControllers();
services.AddAutoMapper(typeof(Program));
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
services.AddScoped<IJwtUtils, JwtUtils>();
services.AddScoped<IUserService, UserService>();

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

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<PuttingPracticeDataContext>();
    if (!dataContext.Database.GetAppliedMigrations().Any())
    {
        dataContext.Database.EnsureDeleted();
    }
    dataContext.Database.Migrate();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
