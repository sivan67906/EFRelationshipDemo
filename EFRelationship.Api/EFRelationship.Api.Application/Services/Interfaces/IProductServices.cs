using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Product;
using EFRelationship.Api.EFRelationship.Api.Domain.Responses;

namespace EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
public interface IProductServices
{
    Task<IEnumerable<GetProduct>> GetAllAsync();
    Task<GetProduct> GetByIdAsync(Guid id);
    Task<Response> CreateAsync(CreateProduct product);
    Task<Response> UpdateAsync(UpdateProduct product);
    Task<Response> DeleteAsync(Guid id);
}
