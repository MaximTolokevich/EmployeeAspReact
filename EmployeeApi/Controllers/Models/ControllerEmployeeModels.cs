using EmployeeApi.Repositories.Models;

namespace EmployeeApi.Controllers.Models
{
    public class ControllerEmployeeModels
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public Car Car { get; set; }
    }
}
