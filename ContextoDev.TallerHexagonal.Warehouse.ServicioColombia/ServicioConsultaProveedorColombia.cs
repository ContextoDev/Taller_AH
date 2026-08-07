using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using ContextoDev.TallerHexagonal.Warehouse.ServicioContrato;

namespace ContextoDev.TallerHexagonal.Warehouse.ServicioColombia
{
    public class ServicioConsultaProveedorColombia : IServicioConsultaProveedor
    {
        IRepositorioProveedor _repositorioProveedor;
        IUnitOfWork _unitOfWork;
        public ServicioConsultaProveedorColombia(IRepositorioProveedor repositorioProveedor, IUnitOfWork unitOfWork)
        {
            _repositorioProveedor = repositorioProveedor;
            _unitOfWork = unitOfWork;
        }

        public List<ProveedorDto> ConsultarProveedores()
        {
            throw new NotImplementedException();
        }

        public ProveedorDto ConsultarProveedorPorId(Guid id)
        {
            // Lógica para consultar el proveedor por RUC en el servicio de Ecuador
            // Aquí puedes implementar la lógica de consulta según tus necesidades
            // Por ejemplo, podrías hacer una llamada a una API externa o consultar una base de datos
            // Supongamos que encontramos un proveedor con el RUC proporcionado
            Proveedor proveedor = _repositorioProveedor.Buscar(id) ?? throw new Exception("Proveedor no encontrado");
            ProveedorDto proveedorEncontrado = new ProveedorDto(proveedor.Ruc.Valor, proveedor.Nombre.Valor, proveedor.Direccion.CallePrincipal, proveedor.Direccion.CalleSecundaria, proveedor.Direccion.Numero, proveedor.Direccion.Ciudad, proveedor.Direccion.Pais);
            proveedorEncontrado.id = proveedor.Id;
            return proveedorEncontrado;
        }

        public ProveedorDto RegistrarProveedor(ProveedorDto proveedorDto)
        {
            RUC rUC = RUC.Crear(proveedorDto.ruc);
            Direccion direccion = Direccion.Crear(proveedorDto.callePrincipal,proveedorDto.calleSecundaria,proveedorDto.numero,proveedorDto.ciudad,proveedorDto.pais);
            Nombre nombre = Nombre.Crear("KIWI");
            Proveedor proveedor = Proveedor.Crear(rUC, direccion, nombre);
            return proveedorDto;



        }
    }
}
