using EmployeeApi.Context;
using EmployeeApi.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository : DbContext , IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void Create(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
        }

        public void Delete(string name)
        {
            var res = _employeeContext.Employees.Where(x => x.Name== name);
            _employeeContext.Employees.RemoveRange(res);
            _employeeContext.SaveChanges();
        }

        public IQueryable<Employee> GetAll()
        {
            return _employeeContext.Employees;
        }
    }
}
