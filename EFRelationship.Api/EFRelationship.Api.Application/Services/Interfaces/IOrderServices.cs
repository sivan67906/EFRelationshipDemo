using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Order;
using EFRelationship.Api.EFRelationship.Api.Domain.Responses;

namespace EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
public interface IOrderServices
{
    Task<IEnumerable<GetOrder>> GetAllAsync();
    Task<GetOrder> GetByIdAsync(Guid id);
    Task<Response> CreateAsync(CreateOrder order);
    Task<Response> UpdateAsync(UpdateOrder order);
    Task<Response> DeleteAsync(Guid id);
}
