using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Client.Pages;

namespace WorkLog.Client.Profiles
{
    public class ViewModelEmployeeProfile : Profile
    {
        public ViewModelEmployeeProfile()
        {
            CreateMap<Employees.ViewModelEmployee, Employee>();
        }
    }
}
