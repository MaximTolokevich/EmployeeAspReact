using EmployeeApi.Controllers.Models;
using EmployeeApi.Service.Options;
using EmployeeApi.Service.ServiceModels;
using System.Collections.Generic;

namespace EmployeeApi.Service
{
    public interface IEmployeeService
    {
        public ServiceEmployeeModel CreateNewEmployee(ControllerEmployeeModels employee);
        public void DeleteEmployeeByName(string name);
        public IEnumerable<ServiceEmployeeModel> GetAll(SearchOptions searchOptions = null);
    }
}