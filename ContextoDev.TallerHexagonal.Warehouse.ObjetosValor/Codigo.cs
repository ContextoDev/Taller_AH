namespace ContextoDev.TallerHexagonal.Warehouse.ObjetosValor
{
    public class Codigo
    {
        public string Valor { get; private set; }
        private Codigo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El código no puede estar vacío.", nameof(valor));
            }
            Valor = valor;
        }
        public static Codigo Crear(string valor)
        {
            return new Codigo(valor);
        }
    }
}
