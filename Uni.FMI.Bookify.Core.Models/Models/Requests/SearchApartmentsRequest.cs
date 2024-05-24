using Uni.FMI.Bookify.Core.Models.Common;

namespace Uni.FMI.Bookify.Core.Models.Models.Requests
{
    public record SearchApartmentsRequest
    {
        public PagingSettings Paging {  get; set; }
    }
}
