using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TransporteChecklist.Infra.Repositories;
using TransporteChecklistAPI.Infra.Data;
using TransporteChecklistAPI.Application.Interfaces;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Transporte Checklist API",
        Version = "v1",
        Description = "Documentação interativa para a API de Transporte Checklist"
    });
});

builder.Services.AddDbContext<ChecklistDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("TransporteChecklistAPI.Infra")
    ));

builder.Services.AddScoped<IChecklistService, ChecklistService>();
builder.Services.AddScoped<IChecklistRepository, ChecklistRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IItemConfiguradoService, ItemConfiguradoService>();
builder.Services.AddScoped<IItemConfiguradoRepository, ItemConfiguradoRepository>();
builder.Services.AddScoped<IItemConfiguradoService, ItemConfiguradoService>();
builder.Services.AddScoped<IItemConfiguradoRepository, ItemConfiguradoRepository>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transporte Checklist API v1");
    c.RoutePrefix = "swagger";
});

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
