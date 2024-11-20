using AutoMapper;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Category;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Order;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Product;
using EFRelationship.Api.EFRelationship.Api.Domain.Entities;

namespace EFRelationship.Api.EFRelationship.Api.Application.Mappings;
public class MappingConfig : Profile
{
    public MappingConfig()
    {
        #region CategoryConfig
        CreateMap<Category, CreateCategory>();
        CreateMap<CreateCategory, Category>();

        CreateMap<Category, UpdateCategory>();
        CreateMap<UpdateCategory, Category>();
        
        CreateMap<Category, GetCategory>();
        CreateMap<GetCategory, Category>();
        #endregion

        #region ProductConfig
        CreateMap<Product, CreateProduct>();
        CreateMap<CreateProduct, Product>();

        CreateMap<Product, UpdateProduct>();
        CreateMap<UpdateProduct, Product>();

        CreateMap<Product, GetProduct>();
        CreateMap<GetProduct, Product>();
        #endregion

        #region OrderConfig
        CreateMap<Order, CreateOrder>();
        CreateMap<CreateOrder, Order>();

        CreateMap<Order, UpdateOrder>();
        CreateMap<UpdateOrder, Order>();

        CreateMap<Order, GetOrder>();
        CreateMap<GetOrder, Order>(); 
        #endregion
    }
}
