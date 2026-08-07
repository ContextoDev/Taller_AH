
namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto
{
    public record ProveedorDto(string ruc, string nombre, string callePrincipal, string calleSecundaria, string numero, string ciudad, string pais)
    {
        public Guid id { get; set; }
    }
}
