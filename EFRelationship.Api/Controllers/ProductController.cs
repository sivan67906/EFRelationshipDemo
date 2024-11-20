using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Product;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFRelationship.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductServices productServices) : ControllerBase
{

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var data = await productServices.GetAllAsync();

        return data.Any() ? Ok(data) : NotFound(data);
    }

    [HttpGet("single/{id:guid}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var data = await productServices.GetByIdAsync(id);

        return data is not null ? Ok(data) : NotFound(data);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateProduct product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await productServices.CreateAsync(product);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateProduct product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await productServices.UpdateAsync(product);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await productServices.DeleteAsync(id);

        return response.Flag ? Ok(response) : BadRequest(response);
    }
}
