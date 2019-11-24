using System;
using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;

namespace WorkLog.Bll
{
    public class BllMapperProfile : Profile
    {
        public BllMapperProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
            CreateMap<Employee, EmployeeEntity>();

            CreateMap<WorkTimeEntity, WorkTime>()
                .ForMember(d => d.Hours, e => e.MapFrom(s => (int)s.Hours.TotalHours));
            CreateMap<WorkTime, WorkTimeEntity>()
                .ForMember(d => d.Hours, e => e.MapFrom(s => TimeSpan.FromHours(s.Hours)));
        }
    }
}