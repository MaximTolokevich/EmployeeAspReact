using EmployeeApi.Repositories.Models;

namespace EmployeeApi.Service.ServiceModels
{
    public class ServiceEmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public Car Car { get; set; }
    }
}
