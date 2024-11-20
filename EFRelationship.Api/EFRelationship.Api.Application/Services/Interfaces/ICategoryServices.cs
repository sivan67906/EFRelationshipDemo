using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Category;
using EFRelationship.Api.EFRelationship.Api.Domain.Responses;

namespace EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
public interface ICategoryServices
{
    Task<IEnumerable<GetCategory>> GetAllAsync();
    Task<GetCategory> GetByIdAsync(Guid id);
    Task<Response> CreateAsync(CreateCategory entity);
    Task<Response> UpdateAsync(UpdateCategory entity);
    Task<Response> DeleteAsync(Guid id);
}
