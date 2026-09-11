using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;
using ContextoDev.TallerHexagonal.Warehouse.ServicioContrato;

namespace ContextoDev.TallerHexagonal.Warehouse.ServicioEcuador
{
    public class ServicioConsultaProveedorEcuador : IServicioConsultaProveedor
    {
        IRepositorioProveedor _repositorioProveedor;
        IUnitOfWork _unitOfWork;


        IRepositorioProveedorMongo _repositorioProveedorMongo;
        IUnitOfWorkMongo _unitOfWorkMongo;


        public ServicioConsultaProveedorEcuador(IRepositorioProveedor repositorioProveedor,IUnitOfWork unitOfWork ,IRepositorioProveedorMongo repositorioProveedorMongo, IUnitOfWorkMongo unitOfWorkMongo)
        {
            _repositorioProveedor = repositorioProveedor;
            _unitOfWork = unitOfWork;

            _repositorioProveedorMongo = repositorioProveedorMongo;
            _unitOfWorkMongo = unitOfWorkMongo;
        }

        public List<ProveedorDto> ConsultarProveedores()
        {
            return _repositorioProveedor.Todos().Select(p => new ProveedorDto(p.Ruc.Valor, p.Nombre.Valor, p.Direccion.CallePrincipal, p.Direccion.CalleSecundaria, p.Direccion.Numero, p.Direccion.Ciudad,p.Direccion.Pais)).ToList();
        }

        public ProveedorDto ConsultarProveedorPorId(Guid id)
        {
            // Lógica para consultar el proveedor por RUC en el servicio de Ecuador
            // Aquí puedes implementar la lógica de consulta según tus necesidades
            // Por ejemplo, podrías hacer una llamada a una API externa o consultar una base de datos
            // Supongamos que encontramos un proveedor con el RUC proporcionado
            Proveedor proveedor = _repositorioProveedor.Buscar(id) ?? throw new Exception("Proveedor no encontrado");
            ProveedorDto proveedorEncontrado = new ProveedorDto(proveedor.Ruc.Valor,proveedor.Nombre.Valor, proveedor.Direccion.CallePrincipal, proveedor.Direccion.CalleSecundaria, proveedor.Direccion.Numero, proveedor.Direccion.Ciudad, proveedor.Direccion.Pais);
            proveedorEncontrado.id = proveedor.Id;
            return proveedorEncontrado;
        }

        public ProveedorDto RegistrarProveedor(ProveedorDto proveedorDto)
        {
            Proveedor proveedor = Proveedor.Crear(RUC.Crear(proveedorDto.ruc), Direccion.Crear(proveedorDto.callePrincipal, proveedorDto.calleSecundaria, proveedorDto.numero, proveedorDto.ciudad, proveedorDto.pais), Nombre.Crear(proveedorDto.nombre));
            _repositorioProveedor.Guardar(proveedor);
            _unitOfWork.SaveChanges();

            _repositorioProveedorMongo.Guardar(proveedor);
            //_unitOfWorkMongo.SaveChanges();

            proveedorDto.id = proveedor.Id;
            return proveedorDto;    
        }
    }
}
