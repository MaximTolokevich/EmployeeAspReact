using EmployeeApi.Repositories.Models;

namespace EmployeeApi.Service.Options
{
    public class SearchOptions
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Car? Car { get; set; }
    }
}