using System;
using System.Text.RegularExpressions;

namespace ContextoDev.TallerHexagonal.Warehouse.ObjetosValor
{
    public class Nombre
    {
        public string Valor { get; internal set; }

        private Nombre()
        { }
        private Nombre(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            if (valor.Length > 200)
            {
                throw new ArgumentException("El nombre no puede tener más de 200 caracteres.");
            }
            if (!Regex.IsMatch(valor, @"^[a-zA-Z\s]+$"))
            {
                throw new ArgumentException("El nombre solo puede contener letras y espacios.");
            }
            Valor = valor.Trim();
        }

        public static Nombre Crear(string valor)
        {
            return new Nombre(valor);

        }
    }
}