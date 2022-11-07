using _2035Cars_Application.DTO;

namespace _2035Cars_Application.ViewModels
{
    public class EmployeesCollectionWithPagination
    {
        public List<EmployeeDTO> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int AmountOfPages { get; set; }
    }
}