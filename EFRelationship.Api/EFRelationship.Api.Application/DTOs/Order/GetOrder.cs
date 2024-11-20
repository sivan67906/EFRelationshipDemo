namespace EFRelationship.Api.EFRelationship.Api.Application.DTOs.Order;
public class GetOrder : OrderBase
{
    public Guid OrderNo { get; set; }
    public string? Description { get; set; }
    public Guid ProductId { get; set; }
}
