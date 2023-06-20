using AutoMapper;
using EmployeeApi.Controllers.Models;
using EmployeeApi.Service;
using EmployeeApi.Service.Options;
using EmployeeApi.Service.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        public HomeController(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }
        [HttpGet]
        public IEnumerable<ControllerEmployeeModels> Get() => GetEmployees();

        [HttpPost]
        public ControllerEmployeeModels CreateNewEmployee(ControllerEmployeeModels employee)
        {
            _employeeService.CreateNewEmployee(employee);
            return employee;
        }

        [HttpPost("search")]
        public IEnumerable<ControllerEmployeeModels> GetBySearch(SearchOptions options) => GetEmployees(options);

        [HttpDelete]
        public void Delete(string name)
        {
            _employeeService.DeleteEmployeeByName(name);
        }

        private IEnumerable<ControllerEmployeeModels> GetEmployees(SearchOptions options = null)
        {
            return _mapper.Map<IEnumerable<ServiceEmployeeModel>,
                               IEnumerable<ControllerEmployeeModels>>(_employeeService.GetAll(options));
        }
    }
}
