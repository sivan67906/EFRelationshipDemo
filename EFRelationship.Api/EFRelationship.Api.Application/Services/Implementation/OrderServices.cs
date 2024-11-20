using AutoMapper;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Category;
using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Order;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Domain.Entities;
using EFRelationship.Api.EFRelationship.Api.Domain.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Domain.Responses;

namespace EFRelationship.Api.EFRelationship.Api.Application.Services.Implementation;
public class OrderServices(IGenericRepository<Order> orderInterface, IMapper mapper) : IOrderServices
{
    public async Task<Response> CreateAsync(CreateOrder order)
    {
        var mapEntity = mapper.Map<Order>(order);
        int response = await orderInterface.CreateAsync(mapEntity);
        return response > 0 ? new Response(true, "Order Created Successfully!")
            : new Response(false, "Unable to create Order");
    }

    public async Task<Response> DeleteAsync(Guid id)
    {
        int response = await orderInterface.DeleteAsync(id);
        if (response == 0) return new Response(false, "delete failed.");
        return new Response(true, "Order deleted successfully!");
    }

    public async Task<IEnumerable<GetOrder>> GetAllAsync()
    {
        IEnumerable<Order> orderList = await orderInterface.GetAllAsync();
        var mapEntity = mapper.Map<IEnumerable<GetOrder>>(orderList);
        return mapEntity;
    }

    public async Task<GetOrder> GetByIdAsync(Guid id)
    {
        Order order = await orderInterface.GetByIdAsync(id);
        var mapEntity = mapper.Map<GetOrder>(order);
        return mapEntity;
    }

    public async Task<Response> UpdateAsync(UpdateOrder order)
    {
        var mapEntity = mapper.Map<Order>(order);
        int response = await orderInterface.UpdateAsync(mapEntity);
        return response > 0 ? new Response(true, "Order Updated Successfully!")
            : new Response(false, "Unable to update Order");
    }
}
