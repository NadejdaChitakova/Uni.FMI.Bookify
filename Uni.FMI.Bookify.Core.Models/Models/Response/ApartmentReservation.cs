namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record ApartmentReservation
{
    public Guid ReservationId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public decimal CleaningPrice { get; set; }
    public decimal PriceForNights { get; set; }
    public decimal Profit { get; set; }
}