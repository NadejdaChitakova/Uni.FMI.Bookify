using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Infrastructure.Data.Configurations;
using Uni.FMI.Bookify.Infrastructure.Models.Common;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public class BookingService(IdentityCoreDbContext dbContext) : IBookingService
    {
        public async Task Reserve(MakeReservationRequest request, string userId)
        {
            Guid apartmentId = Guid.Empty;

            bool isValid = Guid.TryParse(request.ApartmentId, out apartmentId);

             var duration = DateRange.Create(new DateOnly(request.DurationStart.Year, request.DurationStart.Month, request.DurationStart.Day),
                             new DateOnly(request.DurationEnd.Year, request.DurationEnd.Month,
                                          request.DurationEnd.Day));

             Booking reservation = new Booking()
             {
                 ApartmentId = apartmentId,
                 Duration = duration,
                 ApplicationUserId = userId,
                 CleaningFee = request.CleaningFee,
                 PriceForPeriod = request.PriceForPeriod,
                 TotalPrice = request.TotalPrice,
                 Status = BookingStatus.Completed,
                 CreatedOnUtc = DateTime.Now
             };

             dbContext.Set<Booking>()
                 .Add(reservation);

             dbContext.SaveChanges();
        }

        public async Task<List<MyReservationResponse>> GetMyReservation(string userId)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var reservations = dbContext.Set<Booking>()
                .Where(x => x.ApplicationUserId == userId)
                .Select(x => new MyReservationResponse
                {
                    Id = x.Id,
                    ApartmentName = x.Apartment.Name,
                    FromDate = x.Duration.Start,
                    ToDate = x.Duration.End,
                    TotalPrice = x.TotalPrice,
                    CanDeclineReservation = x.Duration.Start > currentDate
                }).ToList();

            return reservations;
        }

        public async Task DeclineReservation(Guid reservationId, CancellationToken cancellationToken)
        {
            var reservation = await dbContext.Set<Booking>()
                .FindAsync(reservationId, cancellationToken);

            if (reservation is not null)
            {
                dbContext.Set<Booking>()
                    .Remove(reservation);

                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
