using Uni.FMI.Bookify.Core.Models.Common;

namespace Uni.FMI.Bookify.Core.Models.Models.Requests
{
    public record SearchApartmentsRequest
    {
        public string SearchByLocationOrName { get; set; }
        public int NumberOfGuests { get; set; }
public Guid? CityId { get; set; }
public Guid? CountryId { get; set; }
public DateTime? FromDate { get; set; }
public DateTime? EndDate { get; set; }
public int? MinPrice { get; set; }
public int? MaxPrice { get; set; }
        public PagingSettings Paging {  get; set; }
    }
}
