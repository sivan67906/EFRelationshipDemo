using AutoMapper;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Category;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Product;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Domain.Entities;
using EFRelationship.Api.EFRelationship.Api.Domain.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Domain.Responses;

namespace EFRelationship.Api.EFRelationship.Api.Application.Services.Implementation;
public class ProductServices(IGenericRepository<Product> productInterface, IMapper mapper) : IProductServices
{
    public async Task<Response> CreateAsync(CreateProduct product)
    {
        var mapEntity = mapper.Map<Product>(product);
        int response = await productInterface.CreateAsync(mapEntity);
        return response > 0 ? new Response(true, "Product Created Successfully!")
            : new Response(false, "Unable to create Product");
    }

    public async Task<Response> DeleteAsync(Guid id)
    {
        int response = await productInterface.DeleteAsync(id);
        if (response == 0) return new Response(false, "delete failed.");
        return new Response(true, "Product deleted successfully!");
    }

    public async Task<IEnumerable<GetProduct>> GetAllAsync()
    {
        IEnumerable<Product> productList = await productInterface.GetAllAsync();
        var mapEntity = mapper.Map<IEnumerable<GetProduct>>(productList);
        return mapEntity;
    }

    public async Task<GetProduct> GetByIdAsync(Guid id)
    {
        Product product = await productInterface.GetByIdAsync(id);
        var mapEntity = mapper.Map<GetProduct>(product);
        return mapEntity;
    }

    public async Task<Response> UpdateAsync(UpdateProduct product)
    {
        var mapEntity = mapper.Map<Product>(product);
        int response = await productInterface.UpdateAsync(mapEntity);
        return response > 0 ? new Response(true, "Product Updated Successfully!")
            : new Response(false, "Unable to update Product");
    }
}
