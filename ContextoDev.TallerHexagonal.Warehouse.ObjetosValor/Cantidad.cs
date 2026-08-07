namespace ContextoDev.TallerHexagonal.Warehouse.ObjetosValor
{
    public class Cantidad
    {
        public int Valor { get; internal set; }

        private Cantidad(int valor)
        {
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "La cantidad no puede ser negativa.");
            }
            Valor = valor;
        }

        public static Cantidad Crear(int valor)
        {
            return new Cantidad(valor);
        }
    }
}
