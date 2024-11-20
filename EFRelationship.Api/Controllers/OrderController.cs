using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Order;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFRelationship.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderServices orderServices) : ControllerBase
{

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var data = await orderServices.GetAllAsync();

        return data.Any() ? Ok(data) : NotFound(data);
    }

    [HttpGet("single/{id:guid}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var data = await orderServices.GetByIdAsync(id);

        return data is not null ? Ok(data) : NotFound(data);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateOrder order)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await orderServices.CreateAsync(order);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateOrder order)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await orderServices.UpdateAsync(order);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await orderServices.DeleteAsync(id);

        return response.Flag ? Ok(response) : BadRequest(response);
    }
}
