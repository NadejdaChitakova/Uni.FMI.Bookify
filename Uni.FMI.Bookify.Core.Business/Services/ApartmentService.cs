using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Core.Models.NewFolder.Requests;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.Common;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;
using Uni_FMI.Bookify.Core.Business.Utils;
using Address = Uni.FMI.Bookify.Insrastructure.Models.DbEntities.Address;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public sealed class ApartmentService(
        IdentityCoreDbContext dbContext,
                                        IMapper mapper,
                                        IConvertPhotoService convertPhotoService) : IApartmentService
    {
        public ApartmentResponse? GetApartment(Guid id)
        {
            var query =  dbContext.Set<Apartment>()
                .Where(x => x.Id == id);

            var result = mapper.ProjectTo<ApartmentResponse>(query);

            return result.FirstOrDefault();
        }

        public async Task<List<ApartmentResponse>> GetApartments(SearchApartmentsRequest request)
        {
            var query = dbContext.Set<Apartment>().AsQueryable();

            var result = mapper.ProjectTo<ApartmentResponse>(query)
                .Skip(request.Paging.PageIndex * request.Paging.PageSize)
                             .Take(request.Paging.PageSize);

            return await result.ToListAsync();
        }

        public async Task Insert(CreateApartmentRequest request)
        {
            var addressId= Guid.NewGuid();

            var entity = new Apartment()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                AddressId = addressId,
                Address = new()
                {
                    Id = addressId,
                    City = new City(),
                    Street = "bul.Bulgaria 105",
                    CountryId = Guid.Parse("178892d1-4b13-48b0-aa92-2fd50e0a1cb3"),
                },
                Price = request.Price,
                CleaningFee = request.CleaningFee,
                OwnewId = "d30466cd-eec5-473e-b8bd-772af9c888f7"
            };

            await dbContext.SaveChangesAsync();

            dbContext.Set<Apartment>()
                .Add(entity);

            await dbContext.SaveChangesAsync();

            var imagesToInsert = dbContext.Set<ApartmentImage>()
                                     .Where(x => request.ApartmentPhotosIds.Contains(x.Id))
                                     .ToList();

            entity.ApartmentImages = new List<ApartmentImage>();

            imagesToInsert.ForEach(x => entity.ApartmentImages.Add(x));

            await dbContext.SaveChangesAsync();

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
            //entity.Address.City = request.City;
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
