using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Data;
using Projekt_Back_End.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BackEndDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BackEndProject"));
});

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<IScreeningRoomRepo, ScreeningRoomRepo>();

builder.Services.AddScoped<IKeyRepository, KeyRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);


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
