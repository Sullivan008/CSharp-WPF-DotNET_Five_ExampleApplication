using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.DataMigration.Interfaces;
using Application.DataAccessLayer.Entities;
using Application.DataAccessLayer.Entities.Enums;

namespace Application.DataAccessLayer.DataMigration
{
    public class ParkingPassDataMigration : IDataMigration
    {
        public async Task SeedAsync(ParkingAppDbContext context)
        {
            if (context.ParkingPass.Any())
            {
                return;
            }

            List<Car> cars = GetCars(context);

            List<ParkingPass> parkingPasses = new()
            {
                new ParkingPass { Number = "PARKING-PASS/1/2021", Car = cars[0], IsKeyPartner = false, PaymentOption = PaymentOption.Daily },
                new ParkingPass { Number = "PARKING-PASS/2/2021", Car = cars[3], IsKeyPartner = true, Discount = 25, PaymentOption = PaymentOption.Monthly },
                new ParkingPass { Number = "PARKING-PASS/3/2021", IsKeyPartner = false, PaymentOption = PaymentOption.Immediately },
                new ParkingPass { Number = "PARKING-PASS/4/2021", IsKeyPartner = true, Discount = 235, PaymentOption = PaymentOption.Monthly }
            };

            await context.ParkingPass.AddRangeAsync(parkingPasses);

            await context.SaveChangesAsync();
        }

        private static List<Car> GetCars(ParkingAppDbContext context)
        {
            return context.Car.ToList();
        }
    }
}
