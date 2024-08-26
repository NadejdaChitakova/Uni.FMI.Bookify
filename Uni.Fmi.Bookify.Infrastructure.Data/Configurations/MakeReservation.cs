namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations;

public record MakeReservationRequest
{
    public string ApartmentId { get; set; }
    public DateTime DurationStart { get; set; }
    public DateTime DurationEnd { get; set; }
    public int PriceForPeriod { get; set; }
    public int CleaningFee  { get; set; }
    public int TotalPrice { get; set; }
};