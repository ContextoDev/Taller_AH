namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public class RUC
    {
        public string Valor { get; internal set; }
        private RUC(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El RUC no puede estar vacío.");
            }
            Valor = valor;
        }

        public static RUC Crear(string valor)
        {
            // Aquí puedes agregar validaciones para el RUC si es necesario
            return new RUC(valor);

        }
    }
  
}