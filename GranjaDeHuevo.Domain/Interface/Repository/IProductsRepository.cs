using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface IProductsRepository : IBaseRespository<Products>
    {
        List<ProductsDTO> GetProducts();
        Task<ProductsDTO> GetProductsById(int id);
    }
}
