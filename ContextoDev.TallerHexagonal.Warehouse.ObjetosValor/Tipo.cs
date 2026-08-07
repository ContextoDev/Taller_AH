namespace ContextoDev.TallerHexagonal.Warehouse.ObjetosValor
{
    public class Tipo
    {
        public string Valor { get; private set; }

        private Tipo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacío.", nameof(valor));
            }

            Valor = valor;
        }

        public static Tipo Crear(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacío.", nameof(valor));
            }
            return new Tipo(valor);
        }
    }
}
