using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Domain.Interface.Service;
using GranjaDeHuevo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class ProductService : BaseService<Products>, IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository, AppGranjaDeHuevoContext context) : base(productsRepository, context)
        {
            _productsRepository = productsRepository;
        }

        public List<ProductsDTO> GetProducts()
        {
            return _productsRepository.GetProducts();
        }

        public override async Task Update(Products products)
        {
            Products productsToUpdate = await _productsRepository.GetId(products.ProductId);

            productsToUpdate.ProductName = products.ProductName;
            productsToUpdate.Description = products.Description;
            productsToUpdate.Price = products.Price;

            productsToUpdate.UserModify = products.UserModify;
            productsToUpdate.ModifyDate = DateTime.Now;

            await base.Update(productsToUpdate);
        }

        public override async Task Remove(Products products)
        {
            Products productsToDelete = await _productsRepository.GetId(products.ProductId);

            productsToDelete.UserDelete = products.UserDelete;
            productsToDelete.Deleted = true;
            productsToDelete.DeletedDate = DateTime.Now;

            await base.Update(productsToDelete);
        }
    }
}
