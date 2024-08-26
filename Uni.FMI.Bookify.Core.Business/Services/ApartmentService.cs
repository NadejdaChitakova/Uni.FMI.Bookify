using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;
using Uni_FMI.Bookify.Core.Business.Utils;

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
            var filter = CreateApartmentFilter(request);

            var query = dbContext.Set<Apartment>()
                .Where(filter)
                .AsQueryable();

            var result = mapper.ProjectTo<ApartmentResponse>(query)
                .Skip(request.Paging.PageIndex * request.Paging.PageSize)
                             .Take(request.Paging.PageSize);

            return await result.ToListAsync();
        }

        public async Task<List<DateOnly>> GetUnavailableDate(GetUnavailableDatesRequest request)
        {
            DateOnly calendarStart = new DateOnly(request.Year, request.Month, 1);
            DateOnly firstDayOfNextMonth = calendarStart.AddMonths(1);
            DateOnly lastDayOfMonth = firstDayOfNextMonth.AddDays(-1);

            var bookings = dbContext.Set<Booking>()
                .Where(x => x.ApartmentId == request.ApartmentId
                            && x.Duration.Start.Month == request.Month
                            && x.Duration.End.Year == request.Year)
                .ToList();

                var dates = GetUnavailableSlots(calendarStart, lastDayOfMonth, bookings);

            return dates;
        }

        public async Task Insert(CreateApartmentRequest request)
        {
            var addressId= Guid.NewGuid();

            var city = dbContext
                .Set<City>()
                .FirstOrDefault(x => x.Name.ToLower() == request.Address.City.ToLower());


            var entity = new Apartment()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                AddressId = addressId,
                Address = new()
                {
                    Id = addressId,
                    City = city,
                    Street = "bul.Bulgaria 105",
                    CountryId = city.CountryId,
                },
                Price = request.Price,
                CleaningFee = request.CleaningFee,
                OwnewId = "03a2426b-0367-4589-a41f-d5e4fce02c3c"
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


        private ExpressionStarter<Apartment> CreateApartmentFilter(SearchApartmentsRequest request)
        {
            var predicate = PredicateBuilder.New<Apartment>();

            if (!request.SearchByLocationOrName.IsNullOrEmpty())
            {
                predicate = predicate.And(x => x.Name == request.SearchByLocationOrName
                                               || x.Address.Country.Name == request.SearchByLocationOrName
                                               || x.Address.City.Name == request.SearchByLocationOrName);
            }

            if (request.NumberOfGuests.HasValue)
            {
                predicate = predicate.And(x => x.NumberOfGuests == request.NumberOfGuests);
            }

            if (request.Duration != null)
            {
                predicate = predicate.And(x => x.Bookings.Any(x => x.Duration == request.Duration
                                                                   && x.Duration.Start >= request.Duration.Start
                                                                   && x.Duration.End <= request.Duration.End));
            }

            if (request.MinPrice.HasValue)
            {
                predicate = predicate.And(x => x.Price >= request.MinPrice);
            }

            if (request.MaxPrice.HasValue)
            {
                predicate = predicate.And(x => x.Price <= request.MaxPrice);
            }

            return predicate;

        }

        public List<DateOnly> GetUnavailableSlots(DateOnly calendarStart, DateOnly calendarEnd, List<Booking> bookings)
        {
            var orderedBookings = bookings.OrderBy(x => x.Duration.Start);
            List<DateOnly> unavailableDates = new();

            foreach (var booking in orderedBookings)
            {
                for (DateOnly i = booking.Duration.Start; i <= booking.Duration.End; i = i.AddDays(1))
                {
unavailableDates.Add(i);
                    }
                }

            return unavailableDates;
        }
        }
        }
    

