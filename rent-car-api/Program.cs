using Microsoft.EntityFrameworkCore;
using rent_car_api.Data;
using rent_car_api.Mapper;
using AutoMapper;
using rent_car_api.Services;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(ObjectMapperProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://localhost:5173")  // Ganti dengan port yang sesuai jika Vue berjalan di port yang berbeda
            .AllowAnyMethod()
            .AllowAnyHeader());
});



builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add CORS middleware here to allow frontend to communicate with backend
app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();
