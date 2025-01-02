using Microsoft.EntityFrameworkCore;

using patika_w14_IdentityDataProtection.Data;
using patika_w14_IdentityDataProtection.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
// DbContext'i Configure Ediyoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add Data Protection service 
builder.Services.AddDataProtection();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// EncryptionService'i scoped olarak ekliyoruz
builder.Services.AddScoped<EncryptionService>();

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
