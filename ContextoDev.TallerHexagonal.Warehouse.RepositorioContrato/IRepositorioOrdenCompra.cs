using ContextoDev.TallerHexagonal.Warehouse.Agregados;

namespace ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato
{
    public interface IRepositorioOrdenCompra
    {
        OrdenCompra Buscar(Guid id);
        void Guardar(OrdenCompra ordenDeCompra);
        IQueryable<OrdenCompra> Todos();
    }
}