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

            CreateMap<Address, AddressResponse>()
                .ForMember(x => x.City, opt => opt.MapFrom(src => src.City.Name));

            CreateMap<City, AddressResponse>()
                .ForMember(x=> x.City, opt => opt.MapFrom(src => src.Name));

            CreateMap<Apartment, ApartmentResponse>()
                .ForMember(x => x.Amenities, opt => opt.MapFrom(src => src.Amenities.Select(y => y.Amenity)))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .AfterMap((src, dest) => dest.Address.City = src.Address.City.Name)
                .ForMember(x => x.ApartmentImages, opt => opt.MapFrom(src => src.ApartmentImages));


            CreateMap<ApartmentResponse, Apartment>()
                .ForMember(x => x.Amenities, opt => opt.MapFrom(src => src.Amenities))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.ApartmentImages, opt => opt.MapFrom(src => src.ApartmentImages));

            //.ForPath(x=> x.Address.CountryId, opt => opt.MapFrom(src=> src.Address.Country.Id));

        }
        }
    }

