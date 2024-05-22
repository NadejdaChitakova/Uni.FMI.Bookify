using Uni.FMI.Bookify.Infrastructure.Models.Common;
using Uni.FMI.Bookify.Insrastructure.Models.Common;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Models.DbEntities
{
    public sealed class Booking
    {
        public Guid Id { get; init; }

        public Guid ApartmentId { get; init; }

        public Guid UserId { get; init; }

        public DateRange Duration { get; init; }

        public Money PriceForPeriod { get; init; }

        public Money CleaningFee { get; init; }

        public Money AmenitiesUpCharge { get; init; }

        public Money TotalPrice { get; init; }

        public BookingStatus Status { get; init; }

        public DateTime CreatedOnUtc { get; init; }

        public DateTime? ConfirmedOnUtc { get; init; }

        public DateTime? RejectedOnUtc { get; init; }

        public DateTime? CompletedOnUtc { get; init; }

        public DateTime? CancelledOnUtc { get; init; }

        public Apartment Apartment { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
