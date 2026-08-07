using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;

namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public class Proveedor:AgregadoRoot
    {
        public RUC Ruc { get; private set; }

        public Direccion Direccion { get; private set; }

        public Nombre Nombre { get; private set; }

        private Proveedor()
        {
        }

        private Proveedor(RUC ruc, Direccion direccion, Nombre nombre)
        {
            Ruc = ruc;
            Direccion = direccion;
            Nombre = nombre;
        }

        public static Proveedor Crear(RUC ruc, Direccion direccion, Nombre nombre)
        {
            return new Proveedor(ruc, direccion, nombre);
        }

        public void CambiarRuc(RUC ruc)
        {
            Ruc = ruc;
        }
    }
}