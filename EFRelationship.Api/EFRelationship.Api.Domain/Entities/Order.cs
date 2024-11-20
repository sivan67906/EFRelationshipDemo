using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Common;

namespace EFRelationship.Api.EFRelationship.Api.Domain.Entities;
public class Order : BaseEntity
{
    public Guid OrderNo { get; set; }
    public string? Description { get; set; }
    public Guid ProductId { get; set; }
}
