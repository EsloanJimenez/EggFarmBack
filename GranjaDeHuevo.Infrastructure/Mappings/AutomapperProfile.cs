using AutoMapper;
using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;

namespace GranjaDeHuevo.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            #region "CUSTOMERS"
            CreateMap<Customers, CustomersDTO>();
            CreateMap<CustomersDTO, Customers>();
            #endregion

            #region "INVENTORY"
            CreateMap<Inventory, InventoryDTO>();
            CreateMap<InventoryDTO, Inventory>();
            #endregion

            #region "ORDERDETAIL"
            CreateMap<OrderDetails, OrderDetailsDTO>();
            CreateMap<OrderDetailsDTO, OrderDetails>();
            #endregion

            #region "ORDER"
            CreateMap<Orders, OrdersDTO>();
            CreateMap<OrdersDTO, Orders>();
            #endregion

            #region "PRODUCTS"
            CreateMap<Products, ProductsDTO>();
            CreateMap<ProductsDTO, Products>();
            #endregion

            #region "USERS"
            CreateMap<Users, UserDTO>();
            CreateMap<UserDTO, Users>();
            #endregion

            #region "ROLE"
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
            #endregion
        }
    }
}
