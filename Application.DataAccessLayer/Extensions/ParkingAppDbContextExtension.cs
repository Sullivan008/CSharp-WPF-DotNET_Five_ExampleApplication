using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using Application.DataAccessLayer.DataMigration;
using Application.DataAccessLayer.DataMigration.Interfaces;
using Application.DataAccessLayer.Extensions.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccessLayer.Extensions
{
    public static class ParkingAppDbContextExtension
    {
        public static async Task InitDatabaseAsync(this ParkingAppDbContext context)
        {
            await context.Database.MigrateAsync();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(ParkingAppDbContext context)
        {
            Type[] migrationTypes = MigrationHelper.GetMigrationTypes();

            IReadOnlySet<IDataMigration> dataMigrations = GetIDataMigrations(migrationTypes);

            foreach (IDataMigration dataMigration in dataMigrations)
            {
                await dataMigration.SeedAsync(context);
            }
        }

        private static IReadOnlySet<IDataMigration> GetIDataMigrations(Type[] migrationTypes)
        {
            HashSet<IDataMigration> result = new()
            {
                MigrationHelper.GetMigration<CarDataMigration>(migrationTypes),
                MigrationHelper.GetMigration<LoggedParkingPeriodDataMigration>(migrationTypes),
                MigrationHelper.GetMigration<ParkingPassDataMigration>(migrationTypes),
                MigrationHelper.GetMigration<CardDataMigration>(migrationTypes)
            };
            
            return result;
        }
    }
}
