using ContextoDev.TallerHexagonal.Warehouse.ObjetosValor;
using System.Text.RegularExpressions;

namespace ContextoDev.TallerHexagonal.Warehouse.Agregados
{
    public partial class Producto : AgregadoRoot
    {
        public Codigo Codigo { get; private set; }

        public Nombre Nombre { get; private set; }

        public Tipo Tipo { get; private set; }

        private Producto() { }
        private Producto(string codigo, string nombre, string tipo, decimal valor)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new ArgumentException("El código no puede ser nulo o vacío.", nameof(codigo));
            }

            Codigo = Codigo.Crear(codigo);

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            }

            if(Regex.Match(nombre, @"^[A-Za-z]+$").Success)
            {
                throw new ArgumentException("El nombre debe contener letras mayúsculas y minúsculas.", nameof(nombre));
            }

            Nombre = Nombre.Crear(nombre);

            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo no puede ser nulo o vacío.", nameof(tipo));
            }

            if(valor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "El valor no puede ser negativo.");
            }

            Tipo = Tipo.Crear(tipo);
            
            Valor = valor;
        }



        public static Producto DarDeAlta(string codigo, string nombre, string tipo,  decimal valor)
        {
            return new Producto(codigo, nombre, tipo, valor);
        }

        public void AgregarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede ser nula o vacía.", nameof(descripcion));
            }
            Descripcion = descripcion;
        }

        public void CambiarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            }
            if(Regex.Match(nombre, @"^[A-Za-z]+$").Success)
            {
                throw new ArgumentException("El nombre debe contener letras mayúsculas y minúsculas.", nameof(nombre));
            }
            Nombre = Nombre.Crear(nombre);
        }

        public void CambiarTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo no puede ser nulo o vacío.", nameof(tipo));
            }
            Tipo = Tipo.Crear(tipo);
        }

        public void CambiarValor(decimal valor)
        {
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "El valor no puede ser negativo.");
            }
            Valor = valor;
        }
    }
}
