using EmployeeApi.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeApi.Builder
{
    public class EmployeeQueryBuilder : IEmployeeQuerybuilder
    {
        private readonly ICollection<Expression<Func<Employee, bool>>> _filters = new List<Expression<Func<Employee, bool>>>();
        private IQueryable<Employee> _baseQuery;

        public IEmployeeQuerybuilder SetBaseQuery(IQueryable<Employee> baseQuery)
        {
            _baseQuery = baseQuery;
            return this;
        }

        public IEmployeeQuerybuilder AddFilter(Expression<Func<Employee, bool>> filter)
        {
            _filters.Add(filter);
            return this;
        }

        public IQueryable<Employee> Build()
        {
            return _filters.Aggregate(_baseQuery, (current, filter) => current.Where(filter));
        }
    }
}
