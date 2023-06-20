namespace EmployeeApi.Repositories.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public Car Car { get; set; }
    }
}
