using EmployeeApi.Repositories.Models;
using System.Linq;

namespace EmployeeApi.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();
        void Create(Employee employee);
        void Delete(string name);
    }
}
