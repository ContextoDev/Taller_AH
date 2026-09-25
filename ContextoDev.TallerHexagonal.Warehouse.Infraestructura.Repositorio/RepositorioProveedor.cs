using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using Microsoft.EntityFrameworkCore;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio
{
    public class RepositorioProveedor : IRepositorioProveedor
    {

        DbContext _dbContext;
        DbSet<Proveedor> _dbSet;

        public RepositorioProveedor(DbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Proveedor>();
        }
        public IQueryable<Proveedor> Todos()
        {
            return _dbSet;
        }

        public Proveedor Buscar(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Guardar(Proveedor proveedor)
        {
            try
            {
                _dbSet.Add(proveedor);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
