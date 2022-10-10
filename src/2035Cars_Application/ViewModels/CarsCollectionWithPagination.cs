using _2035Cars_Application.DTO;

namespace _2035Cars_application.ViewModels
{
    public class CarsCollectionWithPagination
    {
        public List<CarDTO>? cars { get; set; }  
        // public int amountOfAllCars { get; set; }
        public int amountOfPages { get; set; }
        public int currentPage { get; set; }
    }
}