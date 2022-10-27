using _2035Cars_Application.DTO;
using _2035Cars_Core.Domain;
using AutoMapper;

namespace _2035Cars_Application.Mapping
{
    public class RentalProfile : Profile
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Rental, RentalBasicInfo>();
               cfg.CreateMap<Car, CarDTO>()
                            .ForMember(x => x.HasAirCooling, m => m.MapFrom(c => c.Equipment.HasAirCooling))
                            .ForMember(x => x.HasAutomaticGearBox, m => m.MapFrom(c => c.Equipment.HasAutomaticGearBox))
                            .ForMember(x => x.HasBuildInNavigation, m => m.MapFrom(c => c.Equipment.HasBuildInNavigation))
                            .ForMember(x => x.HasHeatingSeats, m => m.MapFrom(c => c.Equipment.HasHeatingSeat))
                            .ForMember(x => x.PriceForRental, m => m.MapFrom(c => c.PriceForOneHour))
                            .ForMember(x => x.CarUniqueReferrence, m => m.MapFrom(c => c.Id))
                            .ReverseMap();
           }).CreateMapper();
    }
}