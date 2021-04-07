using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.ContextFactory.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccessLayer.ContextFactory
{
    public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<ParkingAppDbContext>
    {
        protected override ParkingAppDbContext CreateNewInstance(DbContextOptions<ParkingAppDbContext> options)
        {
            return new(options);
        }
    }
}
