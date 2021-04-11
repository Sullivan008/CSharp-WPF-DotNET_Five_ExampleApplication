using Application.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccessLayer.Context
{
    public class ParkingAppDbContext : DbContext
    {
        public ParkingAppDbContext(DbContextOptions<ParkingAppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ParkingAppDbContext).Assembly);
        }

        #region DbSets

        public DbSet<ApplicationLog> ApplicationLog { get; set; }

        public DbSet<Car> Car { get; set; }

        public DbSet<Card> Card { get; set; }

        public DbSet<ParkingPass> ParkingPass { get; set; }

        public DbSet<LoggedParkingPeriod> LoggedParkingPeriod { get; set; }

        #endregion
    }
}
