using EFRelationship.Api.EFRelationship.Api.Application.DTOs.Common;

namespace EFRelationship.Api.EFRelationship.Api.Domain.Entities;
public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    //public Guid CategoryId { get; set; }

    //[ForeignKey(CategoryId)]
    //public Category Category { get; set; }
}
