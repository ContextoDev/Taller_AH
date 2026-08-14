using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.MySql
{
    public sealed class ProveedorMySqlConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("proveedores");

            builder.HasKey(proveedor => proveedor.Id);

            builder.Property(proveedor => proveedor.Id)
             .HasColumnType("char(36)")
             .ValueGeneratedNever()
             .IsRequired();

            //builder.OwnsOne(p => p.Nombre, nb =>
            //{
            //    nb.Property(n => n.Valor).HasColumnName("Nombre");
            //});

            builder.Property(proveedor => proveedor.Nombre)
           .HasConversion(
               nombre => nombre.Valor,
               value => Nombre.Crear(value))
           .HasColumnName("nombre")
           .HasMaxLength(200)
           .IsRequired();

            builder.Property(proveedor => proveedor.Ruc)
                .HasConversion(
                    ruc => ruc.Valor,
                    value => RUC.Crear(value))
                .HasColumnName("ruc")
                .HasMaxLength(20)
                .IsRequired();

            builder.OwnsOne(proveedor => proveedor.Direccion, direccion =>
            {
                direccion.Property(x => x.CallePrincipal)
                    .HasColumnName("direccion_calle_principal")
                    .HasMaxLength(200)
                    .IsRequired(false);

                direccion.Property(x => x.CalleSecundaria)
                    .HasColumnName("direccion_calle_secundaria")
                    .HasMaxLength(200)
                    .IsRequired(false);

                direccion.Property(x => x.Numero)
                    .HasColumnName("direccion_numero")
                    .HasMaxLength(30)
                    .IsRequired(false);

                direccion.Property(x => x.Ciudad)
                    .HasColumnName("direccion_ciudad")
                    .HasMaxLength(100)
                    .IsRequired(false);

                direccion.Property(x => x.Pais)
                    .HasColumnName("direccion_pais")
                    .HasMaxLength(100)
                    .IsRequired(false);
            });

            builder.HasIndex(proveedor => proveedor.Ruc)
                .IsUnique();
        }
    }
}
