namespace ContextoDev.TallerHexagonal.Warehouse.ObjetosValor
{
    public class SubTotal
    {

        public decimal Valor { get; internal set; }

        private SubTotal(decimal valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("El subtotal no puede ser negativo.");
            }
            Valor = valor;
        }

        public static SubTotal Crear(decimal valor)
        {
            return new SubTotal(valor);
        }
    }
}
