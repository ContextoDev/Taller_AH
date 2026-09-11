using Microsoft.EntityFrameworkCore;
using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Config;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo
{
    public class MongoModeloWareHouse : DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<OrdenCompra> OrdenCompra { get; set; }
        public DbSet<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }


        public MongoModeloWareHouse(DbContextOptions<MongoModeloWareHouse> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>()
            .ToCollection("proveedores");


            modelBuilder.Entity<Producto>()
            .ToCollection("productos");

            base.OnModelCreating(modelBuilder);
        }

    }
}
