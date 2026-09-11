using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Command
{
    public class RegistrarProveedorCommand : IRequest<Guid>
    {
        public string Ruc { get; }
        public string Nombre { get; }
        public string CallePrincipal { get; }
        public string CalleSecundaria { get; }
        public string Numero { get; }
        public string Ciudad { get; }
        public string Pais { get; }

        public RegistrarProveedorCommand(string ruc, string nombre, string callePrincipal, string calleSecundaria, string numero, string ciudad, string pais)
        {
            Ruc = ruc;
            Nombre = nombre;
            CallePrincipal = callePrincipal;
            CalleSecundaria = calleSecundaria;
            Numero = numero;
            Ciudad = ciudad;
            Pais = pais;
        }
    }
}
