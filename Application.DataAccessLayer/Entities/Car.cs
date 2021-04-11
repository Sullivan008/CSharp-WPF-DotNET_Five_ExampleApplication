using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.DataAccessLayer.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LicensePlateNumber { get; set; }

        [Required]
        public string Color { get; set; }

        public int? ParkingPassId { get; set; }

        public ParkingPass ParkingPass { get; set; }

        public int? CardId { get; set; }

        public Card Card { get; set; }

        public ICollection<LoggedParkingPeriod> LoggedParkingPeriods { get; set; }

        public Car()
        {
            LoggedParkingPeriods = new HashSet<LoggedParkingPeriod>();
        }
    }

    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasIndex(x => x.LicensePlateNumber)
                   .IsUnique();

            builder.HasOne(car => car.Card)
                   .WithMany(card => card.Cars);

            builder.HasMany(car => car.LoggedParkingPeriods)
                   .WithOne(loggedInPeriod => loggedInPeriod.Car);
        }
    }
}
