using ContextoDev.TallerHexagonal.Warehouse.Agregados;

namespace ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato
{
    public interface IRepositorioProveedorMongo
    {
        IQueryable<Proveedor> Todos();
        Proveedor Buscar(Guid id);

        void Guardar(Proveedor proveedor);

    }
}
