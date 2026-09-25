

using ContextoDev.TallerHexagonal.Warehouse.Dominio.Eventos;
using MediatR;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Notification
{
    public class ProveedorRegistradoDomainEvent : IDomainEvent,INotification
    {

        public ProveedorRegistradoDomainEvent(Guid id, DateTime utcNow, string ruc, string nombre)
        {
            Id = id;
            FechaOcurrencia = utcNow;
            Ruc = ruc;
            Nombre = nombre;
        }

        public Guid Id { get ; set ; }
        public DateTime FechaOcurrencia { get ; set ; }
        public string Ruc { get ; set ; }
        public string Nombre { get ; set ; }
    }
}