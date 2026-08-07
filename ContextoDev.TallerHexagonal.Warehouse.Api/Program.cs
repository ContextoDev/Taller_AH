using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Config;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Sqlite;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using ContextoDev.TallerHexagonal.Warehouse.ServicioContrato;
using ContextoDev.TallerHexagonal.Warehouse.ServicioEcuador;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IServicioConsultaProveedor, ServicioConsultaProveedorEcuador>();
builder.Services.AddScoped<IRepositorioProveedor, RepositorioProveedor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DbContext, ModeloWareHouse>();

builder.Services.AddScoped<IEntityTypeConfiguration<Proveedor>, ProveedorSqliteConfiguration>();

//builder.Services.AddDbContext<ModeloWareHouse>(options =>
//    options.UseInMemoryDatabase("WareHouseDB", inMemoryOptions =>
//    {
//        inMemoryOptions.EnableNullChecks();
//    }));

builder.Services.AddDbContext<ModeloWareHouse>(options =>
    options.UseSqlite("Data Source=WareHouse.db"));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
