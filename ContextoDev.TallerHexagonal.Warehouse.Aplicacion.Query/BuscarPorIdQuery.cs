using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Query
{
    public class BuscarPorIdQuery : IRequest<ProveedorDto>
    {
        public Guid Id { get; set; }
    }
}
