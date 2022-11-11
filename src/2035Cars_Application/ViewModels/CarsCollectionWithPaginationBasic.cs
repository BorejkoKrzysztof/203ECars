using _2035Cars_Application.DTO;

namespace _2035Cars_Application.ViewModels
{
    public class CarsCollectionWithPaginationBasic
    {
        public List<CarDTO>? cars { get; set; }
        public int amountOfPages { get; set; }
        public int currentPage { get; set; }
    }
}