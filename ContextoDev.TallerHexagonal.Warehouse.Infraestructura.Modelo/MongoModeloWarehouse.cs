using Microsoft.EntityFrameworkCore;
using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Config;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo
{
    public class MongoModeloWareHouse : DbContextMongo
    {
        public DbSet<ProveedorLectura> Proveedores { get; set; }


        public MongoModeloWareHouse(DbContextOptions<MongoModeloWareHouse> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProveedorLectura>()
            .ToCollection("proveedores");


            //modelBuilder.Entity<Producto>()
            //.ToCollection("productos");

            base.OnModelCreating(modelBuilder);
        }

    }
}
