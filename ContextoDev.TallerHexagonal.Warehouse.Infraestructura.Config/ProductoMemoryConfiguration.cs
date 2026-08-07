using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Config
{
    public sealed class ProductoMemoryConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("productos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.OwnsOne(p => p.Nombre, nb =>
            {
                nb.Property(n => n.Valor).HasColumnName("Nombre");
            });

            builder.Property(p => p.Codigo)
                .HasConversion(
                    c => c.Valor,
                    value => Codigo.Crear(value))
                .HasColumnName("codigo")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Tipo)
                .HasConversion(
                    t => t.Valor,
                    value => Tipo.Crear(value))
                .HasColumnName("tipo")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("valor")
                .IsRequired();

            builder.Property(p => p.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}
