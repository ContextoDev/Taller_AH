
using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioContrato;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext _dbContext;
        IMediator _mediator;
        public UnitOfWork(DbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public int SaveChanges()
        {
            try
            {
                DispatchDomainEventsAsync();
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        private void DispatchDomainEventsAsync()
        {
            var aggregates = _dbContext.ChangeTracker
                .Entries<AgregadoRoot>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();

            var domainEvents = aggregates
                .SelectMany(x => x.DomainEvents)
                .ToList();

            aggregates.ForEach(
                aggregate => aggregate.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                 _mediator.Publish(domainEvent);
            }
        }

    }
}
