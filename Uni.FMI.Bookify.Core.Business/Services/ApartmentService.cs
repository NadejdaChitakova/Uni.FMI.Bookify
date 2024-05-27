using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
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

        public async Task Update(UpdateApartmentRequest request)
        {
            var entity = await dbContext.Set<Apartment>()
                             .FindAsync(request.Id);

            if (entity is null)
            {
                //TODO include error model at result model
            }

            var amenities = await dbContext.Set<Amenity>()
                .Where(x => request.AmenitiesId.Contains(x.Id))
                .ToListAsync();

            entity.Address.City = request.City;
            entity.Address.Street = request.Street;
            entity.Amenities = (ICollection<ApartmentAmenity>)amenities;

            //всички снимки, които са за изтриване ( които не съдържат моите)
            var photosForDelete = entity.ApartmentImages
                .Select(x=>x .Id)
                .Where(x => !request.Images.Select(y=> y.Id).Contains(x))
                .ToList();

            photosForDelete.ForEach(x=> entity.ApartmentImages.Remove(entity.ApartmentImages.FirstOrDefault(y=> y.Id == x)));

            if (request.Images.Exists(x=> x.Id is null))
            {
                List<ApartmentImage> photosForInsert = [];

                request.Images.ForEach(x =>
                {
                    if (x.Id is null)
                    {
                        photosForInsert.Add(new ApartmentImage()
                        {
                            Id = new Guid(),
                            Content = x.Content,
                            Extension = x.Extension
                        });
                    }
                });

                photosForInsert.ForEach(x=> entity.ApartmentImages.Add(x));
            }

            await dbContext.SaveChangesAsync();
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
