using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.DataMigration.Interfaces;
using Application.DataAccessLayer.Entities;

namespace Application.DataAccessLayer.DataMigration
{
    public class CarDataMigration : IDataMigration
    {
        public async Task SeedAsync(ParkingAppDbContext context)
        {
            if (context.Car.Any())
            {
                return;
            }

            List<Car> cars = new()
            {
                new Car { LicensePlateNumber = "TEST-LICENSE-PLATE-NUMBER-1", Color = "WHITE" },
                new Car { LicensePlateNumber = "TEST-LICENSE-PLATE-NUMBER-2", Color = "GRAY" },
                new Car { LicensePlateNumber = "TEST-LICENSE-PLATE-NUMBER-3", Color = "BLUE" },
                new Car { LicensePlateNumber = "TEST-LICENSE-PLATE-NUMBER-4", Color = "BLACK" },
                new Car { LicensePlateNumber = "TEST-LICENSE-PLATE-NUMBER-5", Color = "RED" },
                new Car { LicensePlateNumber = "TEST-LICENSE-PLATE-NUMBER-6", Color = "PURPLE" }
            };

            await context.Car.AddRangeAsync(cars);

            await context.SaveChangesAsync();
        }
    }
}
