using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Common;
using EFRelationship.Api.EFRelationship.Api.Domain.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EFRelationship.Api.EFRelationship.Api.Infrastructure.Repositories;
public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : BaseEntity
{
    //private readonly AppDbContext _appDbContext;
    //protected readonly DbSet<TEntity> _dbSet;

    //public GenericRepository(AppDbContext appDbContext)
    //{
    //    _appDbContext = appDbContext;
    //    _dbSet = appDbContext.Set<TEntity>();
    //}

    public async Task<int> CreateAsync(T entity)
    {
        dbContext.Set<T>().Add(entity);
        return await dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var entity = await dbContext.Set<T>().FindAsync(id); //?? throw new ItemNotFoundException($"Item with id: {id} is Not Found!");

        if (entity is null) return 0;

        dbContext.Set<T>().Remove(entity);
        return await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var entity = await dbContext.Set<T>().FindAsync(id); //?? throw new ItemNotFoundException($"Item with id: {id} is Not Found!");

        if (entity is null) return null!;

        return entity;
    }

    public async Task<int> UpdateAsync(T entity)
    {
        dbContext.Set<T>().Update(entity);
        return await dbContext.SaveChangesAsync();
    }

    //public Task<int> UpdateAsync(T entity)
    //{
    //    throw new NotImplementedException();
    //}

    //Task<int> IGenericRepository<T>.CreateAsync(T entity)
    //{
    //    throw new NotImplementedException();
    //}
}
