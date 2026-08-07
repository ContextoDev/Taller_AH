using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;
using Microsoft.AspNetCore.Mvc;
using ContextoDev.TallerHexagonal.Warehouse.ServicioContrato;

namespace ContextoDev.TallerHexagonal.Warehose.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedorController : ControllerBase
    {
        IServicioConsultaProveedor _servicioContrato;
        public ProveedorController(IServicioConsultaProveedor servicioContrato)
        {
            _servicioContrato = servicioContrato;
        }


        [HttpGet]
        [Route("ObtenerProveedores")]
        public IEnumerable<ProveedorDto> Get()
        {
            return _servicioContrato.ConsultarProveedores();
            
        }

        [HttpGet]
        [Route("ObtenerProveedor/{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                return Ok(_servicioContrato.ConsultarProveedorPorId(Guid.Parse(id)));
            }
            catch (Exception)
            {
                return NotFound("Proveedor no encontrado");
            }
        }

        [HttpPost]
        [Route("CrearProveedor")]
        public ProveedorDto Post([FromBody] ProveedorDto proveedorDto)
        {
            return _servicioContrato.RegistrarProveedor(proveedorDto);

        }

    }
}
