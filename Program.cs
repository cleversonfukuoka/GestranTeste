// Program.cs
using GestranTeste.Services;
using GestranTeste.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<GestranContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IChecklistService, ChecklistImplementations>();
builder.Services.AddScoped<IVeiculosService, VeiculoImplementations>();
builder.Services.AddScoped<IUsuariosService, UsuarioImplementations>();
builder.Services.AddScoped<IItensInspecaoService, ItemInspecaoImplementations>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
