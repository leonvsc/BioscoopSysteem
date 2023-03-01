using BioscoopSysteemAPI;
using BioscoopSysteemAPI.Dal.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<MovieRepository>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<VisitorRepository>();


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

