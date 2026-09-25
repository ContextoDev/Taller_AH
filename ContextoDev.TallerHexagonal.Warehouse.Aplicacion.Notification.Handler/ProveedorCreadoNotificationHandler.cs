using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;
using MediatR;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Notification.Handler
{
    public class ProveedorCreadoNotificationHandler : INotificationHandler<ProveedorRegistradoDomainEvent>
    {
        IRepositorioProveedorMongo _repositorioProveedorMongo;
        IUnitOfWorkMongo _unitOfWorkMongo;
        public ProveedorCreadoNotificationHandler(IRepositorioProveedorMongo repositorioProveedorMongo, IUnitOfWorkMongo unitOfWorkMongo)
        {
            _repositorioProveedorMongo = repositorioProveedorMongo;
            _unitOfWorkMongo = unitOfWorkMongo;
        }

        public Task Handle(ProveedorRegistradoDomainEvent notification, CancellationToken cancellationToken)
        {
            ProveedorLectura proveedor = new ProveedorLectura(notification.Id, notification.Ruc, notification.Nombre);
            _repositorioProveedorMongo.Guardar(proveedor);
            _unitOfWorkMongo.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
