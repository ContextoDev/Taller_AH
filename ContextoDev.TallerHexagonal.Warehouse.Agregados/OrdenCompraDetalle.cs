using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;

namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public class OrdenCompraDetalle : Entidad
    {
        public SubTotal Subtotal { get; internal set; }

        public Guid ProductoId { get; internal set; }

        public Producto Producto { get; internal set; }

        public Cantidad Cantidad { get; internal set; }

        public Guid OrdenCompraId { get; internal set; }

        public OrdenCompra OrdenCompra { get; internal set; }

        private OrdenCompraDetalle() { }
        private OrdenCompraDetalle(Producto producto, int cantidad)
        {
            Subtotal = SubTotal.Crear(producto.Valor * cantidad);
            Producto = producto;
            Cantidad = Cantidad.Crear(cantidad);
        }

        public static OrdenCompraDetalle Crear(Producto producto, int cantidad)
        {
            return new OrdenCompraDetalle(producto, cantidad);
        }
    }
}
