using Application.DataAccessLayer.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Core.Application.Configurations
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection ConfigureReadOnlyDbContext(this IServiceCollection services)
        {
            services.AddScoped<ParkingAppReadonlyDbContext>();

            return services;
        }
    }
}
