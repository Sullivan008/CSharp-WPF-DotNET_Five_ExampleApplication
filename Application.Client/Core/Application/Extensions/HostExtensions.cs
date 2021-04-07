using System;
using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Client.Core.Application.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider serviceProvider = scope.ServiceProvider;

                ParkingAppDbContext context = serviceProvider.GetRequiredService<ParkingAppDbContext>();

                context.InitDatabaseAsync().Wait();
            }

            return host;
        }
    }
}
