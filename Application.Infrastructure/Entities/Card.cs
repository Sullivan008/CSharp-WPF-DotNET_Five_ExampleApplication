using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.DataAccessLayer.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        public int ParkingPassId { get; set; }

        public ParkingPass ParkingPass { get; set; }

        public ICollection<Car> Cars { get; set; }

        public Card()
        {
            Cars = new HashSet<Car>();
        }
    }

    public class CardEntityConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasIndex(x => x.Number)
                   .IsUnique();

            builder.HasMany(card => card.Cars)
                   .WithOne(car => car.Card);
        }
    }
}
