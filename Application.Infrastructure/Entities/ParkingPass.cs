using System.ComponentModel.DataAnnotations;
using Application.DataAccessLayer.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.DataAccessLayer.Entities
{
    public class ParkingPass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        public bool IsKeyPartner { get; set; }

        public double? Discount { get; set; }

        public PaymentOption PaymentOption { get; set; }

        public Car Car { get; set; }

        public Card Card { get; set; }
    }

    public class ParkingPassEntityConfiguration : IEntityTypeConfiguration<ParkingPass>
    {
        public void Configure(EntityTypeBuilder<ParkingPass> builder)
        {
            builder.HasIndex(x => x.Number)
                   .IsUnique();

            builder.HasOne(parkingPass => parkingPass.Car)
                   .WithOne(car => car.ParkingPass)
                   .HasForeignKey<Car>(car => car.ParkingPassId);

            builder.HasOne(parkingPass => parkingPass.Card)
                   .WithOne(card => card.ParkingPass)
                   .HasForeignKey<Card>(card => card.ParkingPassId);
        }
    }
}
