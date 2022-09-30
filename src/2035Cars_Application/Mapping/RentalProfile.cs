using AutoMapper;

namespace _2035Cars_Application.Mapping
{
    public class RentalProfile : Profile
    {
         public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
               
            }).CreateMapper();
    }
}