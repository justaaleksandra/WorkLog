using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;

namespace WorkLog.Bll.Profiles
{
    public class BllEmployeeProfile : Profile
    {
        public BllEmployeeProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
        }
    }
}