using ContextoDev.TallerHexagonal.Warehouse.Agregados;
using ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Dto;
using ContextoDev.TallerHexagonal.Warehouse.RepositorioMongoContrato;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContextoDev.TallerHexagonal.Warehouse.Aplicacion.Query.Handler
{
    public class BuscarPorIdQueryHandler : IRequestHandler<BuscarPorIdQuery, ProveedorLectura>
    {
        IRepositorioProveedorMongo _repositorioProveedorMongo;

        public BuscarPorIdQueryHandler(IRepositorioProveedorMongo repositorioProveedorMongo)
        {
            _repositorioProveedorMongo = repositorioProveedorMongo;
        }

        public async Task<ProveedorLectura> Handle(BuscarPorIdQuery request, CancellationToken cancellationToken)
        {
            ProveedorLectura proveedor = _repositorioProveedorMongo.Buscar(request.Id) ?? throw new Exception("Proveedor no encontrado");
            return proveedor;
            
        }
    }
}
