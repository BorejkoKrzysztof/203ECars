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
            }).CreateMapper();
    }
}