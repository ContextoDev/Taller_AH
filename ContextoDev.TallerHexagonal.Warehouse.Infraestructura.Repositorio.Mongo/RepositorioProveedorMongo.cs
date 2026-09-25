using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;

using Microsoft.EntityFrameworkCore;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio.Mongo
{
    public class RepositorioProveedorMongo : IRepositorioProveedorMongo
    {

        DbContextMongo _dbContext;
        DbSet<ProveedorLectura> _dbSet;

        public RepositorioProveedorMongo(DbContextMongo dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<ProveedorLectura>();
        }
        public IQueryable<ProveedorLectura> Todos()
        {
            return _dbSet;
        }

        public ProveedorLectura Buscar(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Guardar(ProveedorLectura proveedor)
        {
            _dbSet.Add(proveedor);
        }
    }
}
