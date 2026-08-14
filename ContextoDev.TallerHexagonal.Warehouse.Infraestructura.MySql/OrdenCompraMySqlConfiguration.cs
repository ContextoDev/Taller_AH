using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.MySql
{
    public sealed class OrdenCompraMySqlConfiguration : IEntityTypeConfiguration<OrdenCompra>
    {
        public void Configure(EntityTypeBuilder<OrdenCompra> builder)
        {
            builder.ToTable("ordenCompra");

            builder.HasKey(ordenCompra => ordenCompra.Id);
            builder.Property(ordenCompra => ordenCompra.Id)
              .HasColumnType("char(36)")
                  .ValueGeneratedNever()
              .IsRequired();

            builder.Property(ordenCompra => ordenCompra.Codigo)
           .HasConversion(
               codigo => codigo.Valor,
               value => Codigo.Crear(value))
           .HasColumnName("codigo")
           .HasMaxLength(20)
           .IsRequired();

            builder.Property(ordenCompra => ordenCompra.Fecha)
             .HasColumnType("datetime(6)")
           .HasColumnName("fecha")
           .IsRequired();

            builder.Property(ordenCompra => ordenCompra.Total)
           .IsRequired();

            builder.HasMany(x => x.Detalles)
            .WithOne(x => x.OrdenCompra)
            .HasForeignKey(x => x.OrdenCompraId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
