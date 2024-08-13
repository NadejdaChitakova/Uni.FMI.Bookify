using Uni.FMI.Bookify.Core.Models.Common;
using Uni.FMI.Bookify.Infrastructure.Models.Common;

namespace Uni.FMI.Bookify.Core.Models.Models.Requests
{
    public record SearchApartmentsRequest
    {
        public string? SearchByLocationOrName { get; set; }
        public int? NumberOfGuests { get; set; }
        public DateRange? Duration { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public PagingSettings Paging {  get; set; }
    }
}
