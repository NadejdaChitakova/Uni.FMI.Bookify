using Uni.FMI.Bookify.Core.Models.Models.Response;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IApartmentService
{
    Task<ApartmentResponse> GetApartment(Guid id);

    Task GetApartments(Guid id);

    Task Insert(Guid id);

    Task Update(Guid id);

    Task Delete(Guid id);

}