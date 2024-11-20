using AutoMapper;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Category;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Domain.Entities;
using EFRelationship.Api.EFRelationship.Api.Domain.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Domain.Responses;

namespace EFRelationship.Api.EFRelationship.Api.Application.Services.Implementation;
public class CategoryServices(IGenericRepository<Category> categoryInterface, IMapper mapper) : ICategoryServices
{
    public async Task<Response> CreateAsync(CreateCategory category)
    {
        var mapEntity = mapper.Map<Category>(category);
        int response = await categoryInterface.CreateAsync(mapEntity);
        return response > 0 ? new Response(true, "Category Created Successfully!") 
            : new Response(false, "Unable to create category");
    }

    public async Task<Response> DeleteAsync(Guid id)
    {
        int response = await categoryInterface.DeleteAsync(id);
        if(response == 0)  return new Response(false, "delete failed.") ;
        return new Response(true, "Category deleted successfully!");
    }

    public async Task<IEnumerable<GetCategory>> GetAllAsync()
    {
        IEnumerable<Category> categoryList = await categoryInterface.GetAllAsync();
        var mapEntity = mapper.Map< IEnumerable<GetCategory>>(categoryList);
        return mapEntity;
    }

    public async Task<GetCategory> GetByIdAsync(Guid id)
    {
        Category category = await categoryInterface.GetByIdAsync(id);
        var mapEntity = mapper.Map<GetCategory>(category);
        return mapEntity;
    }

    public async Task<Response> UpdateAsync(UpdateCategory category)
    {
        var mapEntity = mapper.Map<Category>(category);
        int response = await categoryInterface.UpdateAsync(mapEntity);
        return response > 0 ? new Response(true, "Category Updated Successfully!") 
            : new Response(false, "Unable to update Category");
    }
}
