using System;
using AutoMapper;

namespace WorkLog.Client.Profiles
{
    public class ViewModelWorkTimeProfile : Profile
    {
        public ViewModelWorkTimeProfile()
        {
            CreateMap<Pages.WorkTimes.ViewModelWorkTime, Bll.Models.WorkTime>()
                .ForMember(d => d.Hours, e => e.MapFrom(s => TimeSpan.FromHours(s.Hours)));
        }
    }
}
