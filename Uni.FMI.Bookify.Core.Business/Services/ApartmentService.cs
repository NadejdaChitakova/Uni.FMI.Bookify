using Uni.FMI.Bookify.Infrastructure.Data;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public sealed class ApartmentService(IdentityCoreDbContext dbContext) : IApartmentService
    {
        Task IApartmentService.GetApartment(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IApartmentService.GetApartments(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IApartmentService.Insert(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IApartmentService.Update(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IApartmentService.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
