using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using Microsoft.EntityFrameworkCore;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio
{
    public class RepositorioBase<T> where T : Entidad
    {

        DbContext _dbContext;
        DbSet<T> _dbSet;

        public RepositorioBase(DbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public IQueryable<T> Todos()
        {
            return _dbSet;
        }

        public T Buscar(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Guardar(T entidad)
        {
            _dbSet.Add(entidad);
        }
    }
}
