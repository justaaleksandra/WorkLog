using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;

namespace WorkLog.Bll.Profiles
{
    public class DalEmployeeProfile : Profile
    {
        public DalEmployeeProfile()
        {
            CreateMap<Employee, EmployeeEntity>();
        }
    }
}