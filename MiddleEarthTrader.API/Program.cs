using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiddleEarthTrader.Repository.ContextDb;
using MiddleEarthTrader.Repository.Repositories;
using MiddleEarthTrader.Service.Interfaces;
using MiddleEarthTrader.Service.Mapping;
using MiddleEarthTrader.Service.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<MaterialRepository>();
builder.Services.AddScoped<IGameEventService, GameEventService>();
builder.Services.AddScoped<GameEventRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("https://localhost:7061")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
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

app.UseCors("AllowFrontend");

app.UseAuthorization();


app.MapControllers();

app.Run();
