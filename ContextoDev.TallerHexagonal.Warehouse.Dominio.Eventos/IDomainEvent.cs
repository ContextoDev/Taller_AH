namespace ContextoDev.TallerHexagonal.Warehouse.Dominio.Eventos
{
    public interface IDomainEvent
    {
        public Guid Id { get; set; }
        public DateTime FechaOcurrencia { get; set; }   
    }
}
