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
    public class BuscarPorIdQueryHandler : IRequestHandler<BuscarPorIdQuery, ProveedorDto>
    {
        IRepositorioProveedorMongo _repositorioProveedorMongo;

        public BuscarPorIdQueryHandler(IRepositorioProveedorMongo repositorioProveedorMongo)
        {
            _repositorioProveedorMongo = repositorioProveedorMongo;
        }

        public async Task<ProveedorDto> Handle(BuscarPorIdQuery request, CancellationToken cancellationToken)
        {
            Proveedor proveedor = _repositorioProveedorMongo.Buscar(request.Id) ?? throw new Exception("Proveedor no encontrado");
            ProveedorDto proveedorEncontrado = new ProveedorDto(proveedor.Ruc.Valor, proveedor.Nombre.Valor, proveedor.Direccion.CallePrincipal, proveedor.Direccion.CalleSecundaria, proveedor.Direccion.Numero, proveedor.Direccion.Ciudad, proveedor.Direccion.Pais);
            return proveedorEncontrado;
        }
    }
}
