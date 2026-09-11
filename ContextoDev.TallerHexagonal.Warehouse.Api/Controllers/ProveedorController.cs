using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;
using Microsoft.AspNetCore.Mvc;
using ContextoDev.TallerHexagonal.Warehouse.ServicioContrato;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Command;
using MediatR;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Query;

namespace ContextoDev.TallerHexagonal.Warehose.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedorController : ControllerBase
    {
        IServicioConsultaProveedor _servicioContrato;
        IMediator _mediator;
        public ProveedorController(IServicioConsultaProveedor servicioContrato, IMediator mediator)
        {
            _servicioContrato = servicioContrato;
            _mediator = mediator;
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

        [HttpPost]
        [Route("RegistrarProveedor")]
        public IActionResult PostRegistrar([FromBody] ProveedorDto proveedorDto)
        {
            return Ok(_mediator.Send(new RegistrarProveedorCommand(proveedorDto.ruc, proveedorDto.nombre, proveedorDto.callePrincipal, proveedorDto.calleSecundaria, proveedorDto.numero, proveedorDto.ciudad, proveedorDto.pais)));
        }

        [HttpGet]
        [Route("ObtenerProveedorCQRS/{id}")]
        public ActionResult GetCQRS(string id)
        {
            try
            {
                return Ok(_mediator.Send(new BuscarPorIdQuery { Id = Guid.Parse(id) }));
                
            }
            catch (Exception)
            {
                return NotFound("Proveedor no encontrado");
            }
        }

    }
}
