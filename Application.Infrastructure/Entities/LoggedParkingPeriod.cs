using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.DataAccessLayer.Entities
{
    public class LoggedParkingPeriod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TransactionId { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

    public class LoggedParkingPeriodEntityConfiguration : IEntityTypeConfiguration<LoggedParkingPeriod>
    {
        public void Configure(EntityTypeBuilder<LoggedParkingPeriod> builder)
        {
            builder.HasIndex(x => x.TransactionId)
                   .IsUnique();

            builder.HasOne(loggedInPeriod => loggedInPeriod.Car)
                   .WithMany(car => car.LoggedParkingPeriods);
        }
    }
}
