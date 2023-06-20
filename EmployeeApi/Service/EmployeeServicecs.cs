using AutoMapper;
using EmployeeApi.Builder;
using EmployeeApi.Controllers.Models;
using EmployeeApi.Repositories;
using EmployeeApi.Repositories.Models;
using EmployeeApi.Service.Options;
using EmployeeApi.Service.ServiceModels;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Service
{
    public class EmployeeServicecs : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private IEmployeeQuerybuilder _builder;
        public EmployeeServicecs(IEmployeeRepository employeeRepository, IMapper mapper, IEmployeeQuerybuilder builder)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _builder = builder;
        }
        public ServiceEmployeeModel CreateNewEmployee(ControllerEmployeeModels employee)
        {
            var newModel = _mapper.Map<ServiceEmployeeModel>(employee);
            var repModel = _mapper.Map<Employee>(newModel);

            _employeeRepository.Create(repModel);

            return newModel;
        }

        public void DeleteEmployeeByName(string name)
        {
            _employeeRepository.Delete(name);
        }

        public IEnumerable<ServiceEmployeeModel> GetAll(SearchOptions searchOptions = null)
        {
            var query = _employeeRepository.GetAll();
            _builder = _builder.SetBaseQuery(query);
            if (searchOptions != null)
            {
                _builder.ByCar(searchOptions.Car)
                    .ByAge(searchOptions.Age)
                    .ByName(searchOptions.Name);
            }
            var resultQuery = _builder.Build().ToList();
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<ServiceEmployeeModel>>(resultQuery);
        }
    }
}
