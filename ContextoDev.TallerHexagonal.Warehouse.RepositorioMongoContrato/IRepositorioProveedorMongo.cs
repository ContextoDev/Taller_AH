using ContextoDev.TallerHexagonal.Warehouse.Agregados;

namespace ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato
{
    public interface IRepositorioProveedorMongo
    {
        IQueryable<ProveedorLectura> Todos();
        ProveedorLectura Buscar(Guid id);

        void Guardar(ProveedorLectura proveedor);

    }
}
