using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;

using Microsoft.EntityFrameworkCore;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio.Mongo
{
    public class RepositorioProveedorMongo : IRepositorioProveedorMongo
    {

        DbContext _dbContext;
        DbSet<Proveedor> _dbSet;

        public RepositorioProveedorMongo(DbContext dbContext) 
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
            _dbSet.Add(proveedor);
        }
    }
}
