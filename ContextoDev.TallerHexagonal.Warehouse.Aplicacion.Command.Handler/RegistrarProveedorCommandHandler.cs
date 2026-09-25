using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Notification;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;
using MediatR;


namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Command.Handler
{
    public class RegistrarProveedorCommandHandler : IRequestHandler<RegistrarProveedorCommand, Guid>
    {

        IRepositorioProveedor _repositorioProveedor;
        IUnitOfWork _unitOfWork;

        public RegistrarProveedorCommandHandler(IRepositorioProveedor repositorioProveedor, IUnitOfWork unitOfWork)
        {
            _repositorioProveedor = repositorioProveedor;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegistrarProveedorCommand request, CancellationToken cancellationToken)
        {
            Proveedor proveedor = Proveedor.Crear(RUC.Crear(request.Ruc), Direccion.Crear(request.CallePrincipal, request.CalleSecundaria, request.Numero, request.Ciudad, request.Pais), Nombre.Crear(request.Nombre));
            _repositorioProveedor.Guardar(proveedor);

            proveedor.AddDomainEvent(new ProveedorRegistradoDomainEvent(
                    proveedor.Id,
                    DateTime.UtcNow,
                    request.Ruc,
                    request.Nombre));

            _unitOfWork.SaveChanges();

            return proveedor.Id;
        }
    }
}
