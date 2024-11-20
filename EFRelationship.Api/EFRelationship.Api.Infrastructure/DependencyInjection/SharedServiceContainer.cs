using Microsoft.EntityFrameworkCore;

namespace EFRelationship.Api.EFRelationship.Api.Infrastructure.DependencyInjection;

public static class SharedServiceContainer
{
    public static IServiceCollection AddSharedServices<TContext>(this IServiceCollection services, IConfiguration configuration, string fileName) where TContext : DbContext
    {
        // Add generic database context
        services.AddDbContext<TContext>(opt => opt.UseSqlServer(
            configuration.GetConnectionString("efRelationShipCS"),
            sqlServerOption => sqlServerOption.EnableRetryOnFailure()));

        //opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);


        //// Configure serilog logging
        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Information()
        //    .WriteTo.Debug()
        //    .WriteTo.Console()
        //    .WriteTo.File(path: $"{fileName}-.text", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {message:lj}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
        //    .CreateLogger();

        //// Add JWT
        //JWTAuthenticationScheme.AddJWTAuthenticationScheme(services, configuration);

        return services;
    }

    //public static IApplicationBuilder UseSharedPolicies(this IApplicationBuilder app)
    //{
    //    // Use global exception
    //    app.UseMiddleware<GlobalException>();

    //    // Register middleware to block all outsiders API calls
    //    //app.UseMiddleware<ListenOnlyToGatewayMiddleware>();

    //    return app;
    //}
}
