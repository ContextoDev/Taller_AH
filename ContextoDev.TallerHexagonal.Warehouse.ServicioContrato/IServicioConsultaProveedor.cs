using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;

namespace ContextoDev.TallerHexagonal.Warehouse.ServicioContrato
{
    public interface IServicioConsultaProveedor
    {
        List<ProveedorDto> ConsultarProveedores();
        ProveedorDto ConsultarProveedorPorId(Guid id);
        ProveedorDto RegistrarProveedor(ProveedorDto proveedorDto);
    }
}