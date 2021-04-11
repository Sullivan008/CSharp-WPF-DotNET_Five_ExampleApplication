using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.DataMigration.Interfaces;
using Application.DataAccessLayer.Entities;

namespace Application.DataAccessLayer.DataMigration
{
    public class CardDataMigration : IDataMigration
    {
        public async Task SeedAsync(ParkingAppDbContext context)
        {
            if (context.Card.Any())
            {
                return;
            }

            List<Car> cars = GetCars(context);
            List<ParkingPass> parkingPasses = GetParkingPasses(context);

            List<Card> cards = new()
            {
                new Card { ParkingPass = parkingPasses[2], Number = "CARD-1-2021", Cars = new List<Car> { cars[1], cars[2] } },
                new Card { ParkingPass = parkingPasses[3], Number = "CARD-2-2021", Cars = new List<Car> { cars[4], cars[5] } }
            };

            await context.Card.AddRangeAsync(cards);

            await context.SaveChangesAsync();
        }

        private static List<ParkingPass> GetParkingPasses(ParkingAppDbContext context)
        {
            return context.ParkingPass.ToList();
        }

        private static List<Car> GetCars(ParkingAppDbContext context)
        {
            return context.Car.ToList();
        }
    }
}
