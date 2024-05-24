using System.ComponentModel.DataAnnotations;

namespace Uni.FMI.Bookify.Core.Models.Common
{
    public class PagingSettings
    {
        [Range(1, int.MaxValue, ErrorMessage = GlobalConstants.Wrong)]
        public int PageSize { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = GlobalConstants.Wrong)]
        public int PageIndex { get; set; }
    }
}
