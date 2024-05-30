using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;
using Uni_FMI.Bookify.Core.Business.Utils;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public sealed class ApartmentService(IdentityCoreDbContext dbContext,
                                        IMapper mapper,
                                        IConvertPhotoService convertPhotoService) : IApartmentService
    {
        public async Task<ApartmentResponse?> GetApartment(Guid id)
        {
            var query =  dbContext.Set<Apartment>()
                .Where(x => x.Id == id);

            var result = mapper.ProjectTo<ApartmentResponse>(query);

            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<ApartmentResponse>> GetApartments(SearchApartmentsRequest request)
        {
            var query = dbContext.Set<Apartment>().AsQueryable();

            var result = mapper.ProjectTo<ApartmentResponse>(query)
                .Skip(request.Paging.PageIndex * request.Paging.PageSize)
                             .Take(request.Paging.PageSize);

            return await result.ToListAsync();
        }

        Task IApartmentService.Insert(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UpdateApartmentRequest request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Apartment>()
                             .Include(x=> x.Address)
                             .Include(x=> x.ApartmentImages)
                             .FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                //TODO include error model at result model
            }

            var imagesToInsert = await dbContext.Set<ApartmentImage>()
                .Where(x => request.Images.Contains(x.Id))
                .ToListAsync(cancellationToken);

            var amenities = await dbContext.Set<Amenity>()
                .Where(x => request.AmenitiesId.Contains(x.Id))
                .ToListAsync(cancellationToken);

entity.Description = request.Description;
            entity.Address.City = request.City;
            entity.Address.Street = request.Street;
            entity.Price = request.Price;
            entity.CleaningFee = request.CleaningFee;
imagesToInsert.ForEach(x=> entity.ApartmentImages.Add(x));
            //entity.Amenities = (ICollection<ApartmentAmenity>)amenities;
            
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id)
        {
            var entity = await dbContext.Set<Apartment>()
                             .FindAsync(id);

            if (entity is null)
            {
                //TODO include error model at result model
            }

            dbContext.Set<Apartment>()
                .Remove(entity);

            await dbContext.SaveChangesAsync();
        }

    }
}
