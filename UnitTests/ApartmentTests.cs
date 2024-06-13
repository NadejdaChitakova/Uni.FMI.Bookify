using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Uni.FMI.Bookify.Core.Models.Common;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;
using Uni_FMI.Bookify.Core.Business.Services;
using Uni_FMI.Bookify.Core.Business.Utils;

namespace UnitTests
{
    [TestClass]
    public class ApartmentTests
    {
        private readonly IdentityCoreDbContext _context;
        private IMapper _mapper;
        private readonly IApartmentService _apartmentService;
        private readonly IConvertPhotoService _photoConverter;
        private readonly Apartment apartment;

        public ApartmentTests()
        {
            _photoConverter = new Mock<IConvertPhotoService>().Object;
            apartment = ApartmentFactory();
_context = SetUpDatabase().Object;
             SetUpMapper();
             _apartmentService = new ApartmentService(_context, _mapper, _photoConverter);
            
        }

        public Apartment ApartmentFactory()
        => new Apartment
            {
                Id = Guid.NewGuid(),
                Description = "test",
                Price = 1,
                CleaningFee = 1,
                AddressId = Guid.NewGuid(),
                Amenities = new List<ApartmentAmenity>(),
                ApartmentImages = new List<ApartmentImage>(),
                OwnewId = Guid.NewGuid().ToString(),
                Bookings = new List<Booking>()
            };

        public Mock<IdentityCoreDbContext> SetUpDatabase()
        {
            var apartments = new List<Apartment> { apartment }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Apartment>>();
            dbSetMock.As<IQueryable<Apartment>>().Setup(m => m.Provider).Returns(apartments.Provider);
            dbSetMock.As<IQueryable<Apartment>>().Setup(m => m.Expression).Returns(apartments.Expression);
            dbSetMock.As<IQueryable<Apartment>>().Setup(m => m.ElementType).Returns(apartments.ElementType);
            dbSetMock.As<IQueryable<Apartment>>().Setup(m => m.GetEnumerator()).Returns(apartments.GetEnumerator());

            var dbContextMock = new Mock<IdentityCoreDbContext>();
            dbContextMock.Setup(c => c.Set<Apartment>()).Returns(dbSetMock.Object);
            return dbContextMock;
        }

        public void SetUpMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Apartment, ApartmentResponse>();
                cfg.CreateMap<ApartmentImage, ApartmentImageResponse>();
                cfg.CreateMap<AddressResponse, Address>();

                cfg.CreateMap<Amenity, AmenityResponse>();
                cfg.CreateMap<AmenityResponse, Amenity>();

                cfg.CreateMap<ApartmentImage, ApartmentImageResponse>();
                cfg.CreateMap<ApartmentImageResponse, ApartmentImage>();

                cfg.CreateMap<ApartmentAmenity, ApartmentAmenityResponse>();
                cfg.CreateMap<ApartmentAmenityResponse, ApartmentAmenity>();

                cfg.CreateMap<Apartment, ApartmentResponse>()
                    .ForMember(x => x.Amenities, opt => opt.MapFrom(src => src.Amenities.Select(y => y.Amenity)))
                    .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(x => x.ApartmentImages, opt => opt.MapFrom(src => src.ApartmentImages));

                cfg.CreateMap<Address, AddressResponse>()
                    .ForMember(x => x.City, opt => opt.MapFrom(src => src.City))
                    .ForMember(x => x.Street, opt => opt.MapFrom(src => src.Street));

            });

            _mapper = config.CreateMapper();
        }

    [TestMethod]
        public void ViewApartment_WhenIdIsPresent_ReturnCorrectResponse()
        {
            var result =  _apartmentService.GetApartment(apartment.Id);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ApartmentResponse>();
            result.Id.ShouldBeEquivalentTo(apartment.Id);
            result.Price.ShouldBeEquivalentTo(apartment.Price);
            result.CleaningFee.ShouldBeEquivalentTo(apartment.CleaningFee);
        }

        [TestMethod]
        public void ViewApartment_WhenIdIsNotPresent_ReturnBadRequest()
        {
            var result = _apartmentService.GetApartment(Guid.Empty);

            result.ShouldBeNull();
        }

        [TestMethod]
        public void ViewApartment_WhenIdIsWrong_ReturnBadRequest()
        {
            var result = _apartmentService.GetApartment(Guid.NewGuid());

            result.ShouldBeNull();
        }

        [TestMethod]
        public void GetAll_WhenIdIsPresent_ReturnCorrectResponse()
        {
            var paging = new PagingSettings() { PageIndex = 0, PageSize = 10 };

            var request = new SearchApartmentsRequest() { Paging = paging };

            var result = _apartmentService.GetApartments(request);

            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void Update_WhenCorectDataIsPresent_ReturnBadRequest()
        {
            var request = new UpdateApartmentRequest()
            {
                Id = apartment.Id,
                Description = apartment.Description,
            };

            var result = _apartmentService.Update(request, CancellationToken.None);


            Assert.IsNotNull(result);
        }
    }
}