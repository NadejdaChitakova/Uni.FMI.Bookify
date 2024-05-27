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
            CreateMap<AddressResponse,Address >();

            CreateMap<Amenity, AmenityResponse>();
            CreateMap<AmenityResponse, Amenity>();

            CreateMap<ApartmentImage, ApartmentImageResponse>();
            CreateMap<ApartmentImageResponse, ApartmentImage>();

            CreateMap<ApartmentAmenity, ApartmentAmenityResponse>();
            CreateMap<ApartmentAmenityResponse, ApartmentAmenity>();

            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(x => x.Amenities, opt => opt.MapFrom(src => src.Amenities.Select(y => y.Amenity)))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address));


            CreateMap<ApartmentResponse, Apartment>()
                .ForMember(x => x.Amenities, opt => opt.MapFrom(src => src.Amenities))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address));

            //.ForPath(x=> x.Address.CountryId, opt => opt.MapFrom(src=> src.Address.Country.Id));

        }
        }
    }

