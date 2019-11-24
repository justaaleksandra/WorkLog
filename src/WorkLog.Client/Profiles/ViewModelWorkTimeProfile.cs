using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WorkLog.Bll.Models;

namespace WorkLog.Client.Profiles
{
    public class ViewModelWorkTimeProfile : Profile
    {
        public ViewModelWorkTimeProfile()
        {
            CreateMap<ViewModelWorkTimeProfile, WorkTime>();
        }
    }
}
