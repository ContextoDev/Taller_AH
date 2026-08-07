using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;

namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public class OrdenCompra : AgregadoRoot
    {
        public Codigo Codigo { get; internal set; }

        public DateTime Fecha { get; internal set; } = DateTime.Now;

        public decimal Total { get; internal set; }

        public DateTime FechaEntrega { get; internal set; }

        public List<OrdenCompraDetalle> Detalles { get; internal set; } = new List<OrdenCompraDetalle>();

        private OrdenCompra() { }
        private OrdenCompra(Codigo codigo)
        {
            if (codigo == null)
            {
                throw new ArgumentNullException(nameof(codigo), "El código no puede ser nulo.");
            }

            Codigo = codigo;
        }

        public static OrdenCompra Crear(Codigo codigo)
        {
            return new OrdenCompra(codigo);
        }

        public void AgregarDetalle(OrdenCompraDetalle detalle)
        {
            if (detalle == null)
            {
                throw new ArgumentNullException(nameof(detalle), "El detalle no puede ser nulo.");
            }
            Detalles.Add(detalle);
            Total += detalle.Subtotal.Valor;
        }

        public void BuscarDetalle(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "El Id no puede ser nulo.");
            }
            var detalle = Detalles.FirstOrDefault(d => d.Id == id);

        }

        public void CambiarFechaEntrega(DateTime fechaEntrega)
        {
            if (fechaEntrega < DateTime.Now)
            {
                throw new ArgumentException("La fecha de entrega no puede ser anterior a la fecha actual.");
            }
            FechaEntrega = fechaEntrega;
        }

        public void CambiarCodigo(Codigo codigo)
        {
            if (codigo == null)
            {
                throw new ArgumentNullException(nameof(codigo), "El código no puede ser nulo.");
            }
            Codigo = codigo;

        }

        public void CambiarFecha(DateTime fecha)
        {
            if (fecha > DateTime.Now)
            {
                throw new ArgumentException("La fecha no puede ser posterior a la fecha actual.");
            }
            Fecha = fecha;
        }

        public void ValidarExistenciaDetalles()
        {
            if (Detalles == null || !Detalles.Any())
            {
                throw new InvalidOperationException("La orden de compra debe tener al menos un detalle.");
            }
        }
    }
}
