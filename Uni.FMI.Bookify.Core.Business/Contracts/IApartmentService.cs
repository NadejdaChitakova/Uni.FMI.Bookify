using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IApartmentService
{
    ApartmentResponse? GetApartment(Guid id);

    Task<List<ApartmentResponse>> GetApartments(SearchApartmentsRequest request);

    Task<List<DateOnly>> GetUnavailableDate(GetUnavailableDatesRequest request);

    Task Insert(CreateApartmentRequest request);

    Task Update(UpdateApartmentRequest request, CancellationToken cancellationToken);

    Task Delete(Guid id);

}