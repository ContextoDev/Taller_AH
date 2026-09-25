using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ContextoDev.TallerHexagonal.Warehouse.Agregados;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Query
{
    public class BuscarPorIdQuery : IRequest<ProveedorLectura>
    {
        public Guid Id { get; set; }
    }
}
