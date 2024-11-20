
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Common;

namespace EFRelationship.Api.EFRelationship.Api.Domain.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<int> CreateAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(Guid id);
}
