namespace ContextoDev.TallerHexagonal.Warehouse.ObjetosValor
{
    public class Direccion
    {
        public string CallePrincipal { get; private set; }
        public string? CalleSecundaria { get; private set; }
        public string? Numero { get; private set; }
        public string Ciudad { get; private set; }
        public string Pais { get; private set; }
        private Direccion(string callePrincipal, string? calleSecundaria, string? numero, string ciudad, string pais)
        {
            if (string.IsNullOrWhiteSpace(callePrincipal))
            {
                throw new ArgumentException("La calle principal no puede estar vacía.", nameof(callePrincipal));
            }

            if (string.IsNullOrWhiteSpace(ciudad))
            {
                throw new ArgumentException("La ciudad no puede estar vacía.", nameof(callePrincipal));
            }
            if (string.IsNullOrWhiteSpace(pais))
            {
                throw new ArgumentException("El país no puede estar vacío.", nameof(callePrincipal));
            }

            CallePrincipal = callePrincipal;
            CalleSecundaria = calleSecundaria;
            Numero = numero;
            Ciudad = ciudad;
            Pais = pais;
        }

        public static Direccion Crear(string callePrincipal, string? calleSecundaria, string? numero, string ciudad, string pais)
        {
            return new Direccion(callePrincipal, calleSecundaria, numero, ciudad, pais);
        }
    }
}
