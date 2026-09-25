using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Command.Handler;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Notification.Handler;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Query.Handler;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Config;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.MySql;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio.Mongo;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Sqlite;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;
using ContextoDev.TallerHexagonal.Warehouse.ServicioContrato;
using ContextoDev.TallerHexagonal.Warehouse.ServicioEcuador;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IServicioConsultaProveedor, ServicioConsultaProveedorEcuador>();
builder.Services.AddScoped<IRepositorioProveedor, RepositorioProveedor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DbContext, ModeloWareHouse>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<RegistrarProveedorCommandHandler>();
    cfg.RegisterServicesFromAssemblyContaining<BuscarPorIdQueryHandler>();
    cfg.RegisterServicesFromAssemblyContaining<ProveedorCreadoNotificationHandler>();
});


builder.Services.AddScoped<IRepositorioProveedorMongo, RepositorioProveedorMongo>();
builder.Services.AddScoped<IUnitOfWorkMongo, UnitOfWorkMongo>();
builder.Services.AddScoped<DbContextMongo, MongoModeloWareHouse>();

builder.Services.AddScoped<IEntityTypeConfiguration<Proveedor>, ProveedorMySqlConfiguration>();

//builder.Services.AddDbContext<ModeloWareHouse>(options =>
//    options.UseInMemoryDatabase("WareHouseDB", inMemoryOptions =>
//    {
//        inMemoryOptions.EnableNullChecks();
//    }));

//builder.Services.AddDbContext<ModeloWareHouse>(options =>
//    options.UseSqlite("Data Source=WareHouse.db"));

builder.Services.AddDbContext<ModeloWareHouse>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WareHouse")
    ));

//builder.Services.AddDbContext<ModeloWareHouse>(options =>
//    options.UseNpgsql(
//        builder.Configuration.GetConnectionString("PostgreSQL")
//    ));

//builder.Services.AddDbContext<ModeloWareHouse>(options =>
//    options.UseMySQL(
//        builder.Configuration.GetConnectionString("MySQL")
//    ));


var mongoClient = new MongoClient(
    builder.Configuration.GetConnectionString("MongoDB"));

builder.Services.AddDbContext<MongoModeloWareHouse>(options =>
    options.UseMongoDB(mongoClient, "WareHouse"));

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
