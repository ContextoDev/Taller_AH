using Microsoft.EntityFrameworkCore;
using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Config;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo
{
    public class ModeloWareHouse : DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        //public DbSet<Producto> Producto { get; set; }
        //public DbSet<OrdenCompra> OrdenCompra { get; set; }
        //public DbSet<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }


        IEntityTypeConfiguration<Proveedor> _proveedorConfiguration;
        //IEntityTypeConfiguration<Producto> _productoConfiguration;

        public ModeloWareHouse(DbContextOptions<ModeloWareHouse> options, IEntityTypeConfiguration<Proveedor> proveedorConfiguration)
            : base(options)
        {
            _proveedorConfiguration = proveedorConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProveedorMemoryConfiguration).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(_proveedorConfiguration.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
