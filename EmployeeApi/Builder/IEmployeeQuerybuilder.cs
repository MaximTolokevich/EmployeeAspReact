using EmployeeApi.Repositories.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeApi.Builder
{
    public interface IEmployeeQuerybuilder
    {
        IEmployeeQuerybuilder SetBaseQuery(IQueryable<Employee> baseQuery);
        IEmployeeQuerybuilder AddFilter(Expression<Func<Employee, bool>> filter);
        IQueryable<Employee> Build();
    }
}