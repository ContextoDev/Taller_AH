using ContextoDev.TallerHexagonal.Warehouse.Agregados;

namespace ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato
{
    public interface IRepositorioProveedor
    {
        IQueryable<Proveedor> Todos();
        Proveedor Buscar(Guid id);

        void Guardar(Proveedor proveedor);

    }
}
