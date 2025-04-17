using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface IProductService : IBaseService<Products>
    {
        List<ProductsDTO> GetProducts();
    }
}
