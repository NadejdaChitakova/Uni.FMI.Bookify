using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data.Configurations;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IBookingService
{
    Task Reserve(MakeReservationRequest request, string userId);
    Task<List<MyReservationResponse>> GetMyReservation(string userId);
    Task DeclineReservation(int reservationId, CancellationToken cancellationToken)
}