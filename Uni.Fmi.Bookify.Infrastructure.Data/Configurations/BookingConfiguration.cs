using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.ApplicationUserId)
                .IsRequired();

            builder.HasOne(x => x.Apartment)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x=> x.ApartmentId);

            builder.HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x=> x.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(booking => booking.Duration);

            builder.OwnsOne(booking => booking.PriceForPeriod, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency);
            });

            builder.OwnsOne(booking => booking.CleaningFee, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency);
            });

            builder.OwnsOne(booking => booking.AmenitiesUpCharge, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency);
            });

            builder.OwnsOne(booking => booking.TotalPrice, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency);
            });
        }
    }
}
