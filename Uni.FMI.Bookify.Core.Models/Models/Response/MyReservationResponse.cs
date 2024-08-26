namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record MyReservationResponse
{
    public Guid Id { get; set; }
    public string ApartmentName { get; set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public decimal TotalPrice { get; set; }
    public bool CanDeclineReservation{ get; set; }
};