using AutoMapper;
using WorkLog.Bll.Models;

namespace WorkLog.Client
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Employee, Pages.Employees.EmployeeViewModel>();
            CreateMap<Pages.Employees.EmployeeViewModel, Employee>();

            CreateMap<WorkTime, Pages.WorkTimes.WorkTimeViewModel>()
                .ForMember(d => d.Hours, e => e.MapFrom(s => s.Hours.ToString("h")));
            CreateMap<Pages.WorkTimes.WorkTimeViewModel, WorkTime>();
        }
    }
}
