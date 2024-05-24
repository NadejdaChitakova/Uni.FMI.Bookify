using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public sealed class ApartmentService(IdentityCoreDbContext dbContext,
                                        IMapper mapper) : IApartmentService
    {
        public async Task<ApartmentResponse?> GetApartment(Guid id)
        {
            var query =  dbContext.Set<Apartment>()
                .Where(x => x.Id == id);

            var result = mapper.ProjectTo<ApartmentResponse>(query);

            return await result.FirstOrDefaultAsync();
        }

        public async Task<ApartmentResponse> GetApartments()
        {
            var query = dbContext.Set<Apartment>();

            var result = mapper.ProjectTo<ApartmentResponse>(query);

            return await result.ToListAsync();
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
