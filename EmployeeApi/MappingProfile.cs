using AutoMapper;
using EmployeeApi.Controllers.Models;
using EmployeeApi.Repositories.Models;
using EmployeeApi.Service.ServiceModels;
using System.Collections;
using System.Collections.Generic;

namespace EmployeeApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ControllerEmployeeModels, ServiceEmployeeModel>().ReverseMap();
            CreateMap<Employee, ServiceEmployeeModel>().ReverseMap();
        }
    }
}