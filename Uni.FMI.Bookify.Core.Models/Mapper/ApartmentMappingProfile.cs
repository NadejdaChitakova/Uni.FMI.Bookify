using AutoMapper;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Core.Models.Mapper
{
    public class ApartmentMappingProfile : Profile
    {
        public ApartmentMappingProfile()
        { 
            CreateMap<Address, AddressResponse>();
            CreateMap<Amenity, AmenityResponse>();
            CreateMap<ApartmentImage, ApartmentImageResponse>();
            CreateMap<ApartmentAmenity, ApartmentAmenityResponse>();
            CreateMap<ApartmentAmenity, ApartmentAmenityResponse>();

            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(x=> x.Amenities, opt => opt.MapFrom(src=> src.Amenities.Select(y=> y.Amenity)));
        }
        }
    }

