using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Config
{
    public sealed class OrdenCompraDetalleMemoryConfiguration : IEntityTypeConfiguration<OrdenCompraDetalle>
    {
        public void Configure(EntityTypeBuilder<OrdenCompraDetalle> builder)
        {
            builder.ToTable("ordenCompraDetalle");

            builder.HasKey(ordenCompraDetalle => ordenCompraDetalle.Id);
            builder.Property(ordenCompraDetalle => ordenCompraDetalle.Id)
              .ValueGeneratedNever();


            builder.Property(ordenCompraDetalle => ordenCompraDetalle.ProductoId)
           .IsRequired();

            builder.Property(ordenCompraDetalle => ordenCompraDetalle.OrdenCompraId)
           .IsRequired();


            builder.Property(ordenCompraDetalle => ordenCompraDetalle.Subtotal)
           .HasConversion(
              subtotal => subtotal.Valor,
              value => SubTotal.Crear(value))
           .HasColumnName("subtotal")
           .IsRequired();

            builder.Property(ordenCompraDetalle => ordenCompraDetalle.Cantidad)
            .HasConversion(
               cantidad => cantidad.Valor,
               value => Cantidad.Crear(value))
            .HasColumnName("cantidad")
            .IsRequired();

            builder.HasOne<Producto>()
            .WithMany()
            .HasForeignKey(x => x.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
