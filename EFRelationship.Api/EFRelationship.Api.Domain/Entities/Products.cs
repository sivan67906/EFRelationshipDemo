using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EFRelationship.Api.EFRelationship.Api.Domain.Entities
{
    public class Products
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid ParentId { get; set; }
        public Guid CatalogId { get; set; }
        public Guid UOMId { get; set; }
        public int OverallRating { get; set; }
        public bool IsActive { get; set; }

        // Foreign Key Property
        [ForeignKey("ProductsUOM")]
        public Guid ProductsUOMId { get; set; }
        // Navigation Properties
        public ProductsUOM? ProductsUOM { get; set; }
    }

    public class ProductsUOM
    {
        [Key]
        public Guid Id { get; set; }
        public string? UOM { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public ICollection<Products>? Products { get; set; }
    }
}
