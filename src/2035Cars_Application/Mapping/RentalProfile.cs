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
               cfg.CreateMap<Car, CarDetailsDTO>()
                           .ForMember(x => x.HasAirCooling, m => m.MapFrom(c => c.Equipment.HasAirCooling))
                           .ForMember(x => x.HasAutomaticGearBox, m => m.MapFrom(c => c.Equipment.HasAutomaticGearBox))
                           .ForMember(x => x.HasBuildInNavigation, m => m.MapFrom(c => c.Equipment.HasBuildInNavigation))
                           .ForMember(x => x.HasHeatingSeats, m => m.MapFrom(c => c.Equipment.HasHeatingSeat))
                           .ForMember(x => x.PriceForRental, m => m.MapFrom(c => c.PriceForOneHour))
                           .ForMember(x => x.CarUniqueReferrence, m => m.MapFrom(c => c.Id))
                           .ForMember(x => x.CarType, m => m.MapFrom(c => (int)c.CarType))
                           .ForMember(x => x.DriveType, m => m.MapFrom(c => (int)c.DriveType))
                           .ReverseMap();
               cfg.CreateMap<Employee, EmployeeDTO>()
                            .ForMember(x => x.FirstName, m => m.MapFrom(c => c.Person.FirstName))
                            .ForMember(x => x.LastName, m => m.MapFrom(c => c.Person.LastName))
                            .ForMember(x => x.PhoneNumber, m => m.MapFrom(c => c.Person.PhoneNumber))
                            .ReverseMap();
           }).CreateMapper();
    }
}