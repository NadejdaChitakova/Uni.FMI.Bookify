namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IApartmentService
{
    Task GetApartment(Guid id);

    Task GetApartments(Guid id);

    Task Insert(Guid id);

    Task Update(Guid id);

    Task Delete(Guid id);

}