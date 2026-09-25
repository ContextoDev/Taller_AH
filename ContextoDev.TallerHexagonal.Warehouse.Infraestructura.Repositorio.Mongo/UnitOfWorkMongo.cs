using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;
using Microsoft.EntityFrameworkCore;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio.Mongo
{
    public class UnitOfWorkMongo : IUnitOfWorkMongo
    {
        DbContextMongo _dbContext;
        public UnitOfWorkMongo(DbContextMongo dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
