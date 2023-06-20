using EmployeeApi.Repositories.Models;

namespace EmployeeApi.Builder
{
    public static class BuilderExtension
    {
        public static IEmployeeQuerybuilder ByName(this IEmployeeQuerybuilder builder, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                builder.AddFilter(item => item.Name.Equals(name));
            }

            return builder;
        }
        public static IEmployeeQuerybuilder ByAge(this IEmployeeQuerybuilder builder, int? age)
        {
            if (age != null)
            {
                builder.AddFilter(item=> item.Age == age);
            }
            return builder;
        }
        public static IEmployeeQuerybuilder ByCar(this IEmployeeQuerybuilder builder, Car? car)
        {
            if (car != null)
            {
                builder.AddFilter(item => item.Car == car);
            }

            return builder;
        }
    }
}
