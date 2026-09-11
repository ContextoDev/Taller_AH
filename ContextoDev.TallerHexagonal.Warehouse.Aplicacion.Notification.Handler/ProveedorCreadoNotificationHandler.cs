using MediatR;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Notification.Handler
{
    public class ProveedorCreadoNotificationHandler : INotificationHandler<ProveedorRegistradoDomainEvent>
    {
        public Task Handle(ProveedorRegistradoDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
