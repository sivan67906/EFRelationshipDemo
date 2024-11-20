using EFRelationship.Api.EFRelationship.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EFRelationship.Api.EFRelationship.Api.Infrastructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add database connectivity
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-R535RRN;Initial Catalog=EFRelationShipDB;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=true"));
        return services;
    }
}
