namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public abstract class Entidad
    {
        public Guid Id { get; private set; }
      
        public DateTime FechaCreacion { get; private set; } = DateTime.UtcNow;

        public DateTime FechaModificacion { get; private set; } = DateTime.UtcNow;

        public Entidad()
        {
            Id = Guid.NewGuid();
        }   
    }
}
