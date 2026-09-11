using ContextoDev.TallerHexagonal.Warehouse.Dominio.Eventos;

namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public abstract class AgregadoRoot: Entidad
    {

        private readonly List<IDomainEvent> _domainEvents = [];

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
