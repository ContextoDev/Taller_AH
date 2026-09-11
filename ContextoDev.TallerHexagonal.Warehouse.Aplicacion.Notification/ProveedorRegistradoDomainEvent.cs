

using ContextoDev.TallerHexagonal.Warehouse.Dominio.Eventos;
using MediatR;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Notification
{
    public class ProveedorRegistradoDomainEvent : IDomainEvent,INotification
    {

        public ProveedorRegistradoDomainEvent(Guid id, DateTime utcNow)
        {
            Id = id;
           FechaOcurrencia = utcNow;
        }

        public Guid Id { get ; set ; }
        public DateTime FechaOcurrencia { get ; set ; }
    }
}