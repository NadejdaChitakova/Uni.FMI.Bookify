namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record GetMyApartmentsReservations
{
    public Guid ApartmentId { get; set; }
    public string ApartmentName {  get; set; }
    public decimal? EntireProfit { get; set; }
    public List<ApartmentReservation> Reservations {  get; set; }

};