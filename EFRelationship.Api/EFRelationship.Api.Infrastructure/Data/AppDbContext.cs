using EFRelationship.Api.EFRelationship.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFRelationship.Api.EFRelationship.Api.Infrastructure.Data;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-R535RRN;Initial Catalog=EFRelationShipDB;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=true");
    //}
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Products>? ProductList { get; set; }
    public DbSet<ProductsUOM>? ProductUOMList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>().Property(p => p.Id).HasDefaultValueSql("newid()");
        modelBuilder.Entity<ProductsUOM>().Property(p => p.Id).HasDefaultValueSql("newid()");
    }
}
