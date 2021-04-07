using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.DataMigration.Interfaces;
using Application.DataAccessLayer.Entities;

namespace Application.DataAccessLayer.DataMigration
{
    public class LoggedParkingPeriodDataMigration : IDataMigration
    {
        public async Task SeedAsync(ParkingAppDbContext context)
        {
            if (context.LoggedParkingPeriod.Any())
            {
                return;
            }

            List<Car> cars = GetCars(context);

            List<LoggedParkingPeriod> loggedParkingPeriods = new()
            {
                new LoggedParkingPeriod { Car = cars[0], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(1) },
                new LoggedParkingPeriod { Car = cars[0], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now.AddHours(1), EndDate = DateTime.Now.AddHours(5) },
                new LoggedParkingPeriod { Car = cars[1], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(3) },
                new LoggedParkingPeriod { Car = cars[1], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now.AddHours(2), EndDate = DateTime.Now.AddHours(2) },
                new LoggedParkingPeriod { Car = cars[2], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(12) },
                new LoggedParkingPeriod { Car = cars[2], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now.AddHours(3), EndDate = DateTime.Now.AddHours(8) },
                new LoggedParkingPeriod { Car = cars[3], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(2) },
                new LoggedParkingPeriod { Car = cars[3], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now.AddHours(4), EndDate = DateTime.Now.AddHours(11) },
                new LoggedParkingPeriod { Car = cars[4], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(10) },
                new LoggedParkingPeriod { Car = cars[4], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now.AddHours(5), EndDate = DateTime.Now.AddHours(9) },
                new LoggedParkingPeriod { Car = cars[5], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(8) },
                new LoggedParkingPeriod { Car = cars[5], TransactionId = Guid.NewGuid().ToString(), StartDate = DateTime.Now.AddHours(4), EndDate = DateTime.Now.AddHours(7) }
            };

            await context.LoggedParkingPeriod.AddRangeAsync(loggedParkingPeriods);

            await context.SaveChangesAsync();
        }

        private static List<Car> GetCars(ParkingAppDbContext context)
        {
            return context.Car.ToList();
        }
    }
}
