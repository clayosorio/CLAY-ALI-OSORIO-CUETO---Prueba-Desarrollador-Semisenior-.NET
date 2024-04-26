using PruebaTecnicaOnOff.Api.Auth;
using PruebaTecnicaOnOff.Application.Servicios;
using PruebaTecnicaOnOff.Application.Servicios.IServicios;
using PruebaTecnicaOnOff.Infrastructure.Context;
using PruebaTecnicaOnOff.Infrastructure.Repository;
using PruebaTecnicaOnOff.Infrastructure.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<PruebaTecnicaOnOffContext>(builder.Configuration.GetConnectionString("connectionStringEF"));
builder.Services.AddScoped<IPremioSorteoRepository, PremioSorteoRepository>();
builder.Services.AddScoped<IPremioSorteoService, PremioSorteoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
