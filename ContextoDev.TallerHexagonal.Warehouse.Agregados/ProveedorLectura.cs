using ContextoDev.TallerHexagonal.Warehouse.Dominio.Eventos;
using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;

namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public class ProveedorLectura
    {
        public Guid Id { get; private set; }
        public string Ruc { get; private set; }
        public string Nombre { get; private set; }

        public ProveedorLectura(Guid id,string ruc, string nombre)
        {
            Id = id;
            Ruc = ruc;
            Nombre = nombre;
        }
    }
}