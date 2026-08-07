using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using Microsoft.EntityFrameworkCore;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio
{
    public class RepositorioOrdenCompra : IRepositorioOrdenCompra
    {

        DbContext _dbContext;
        DbSet<OrdenCompra> _dbSet;

        public RepositorioOrdenCompra(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<OrdenCompra>();
        }
        public IQueryable<OrdenCompra> Todos()
        {
            return _dbSet;
        }

        public OrdenCompra Buscar(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Guardar(OrdenCompra ordenDeCompra)
        {
            _dbSet.Add(ordenDeCompra);
        }
    }
}
