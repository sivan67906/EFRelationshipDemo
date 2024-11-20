using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Category;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFRelationship.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryServices categoryServices) : ControllerBase
{

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var data = await categoryServices.GetAllAsync();

        return data.Any() ? Ok(data) : NotFound(data);
    }

    [HttpGet("single/{id:guid}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var data = await categoryServices.GetByIdAsync(id);

        return data is not null ? Ok(data) : NotFound(data);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateCategory category)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await categoryServices.CreateAsync(category);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateCategory category)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await categoryServices.UpdateAsync(category);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await categoryServices.DeleteAsync(id);

        return response.Flag ? Ok(response) : BadRequest(response);
    }
}
