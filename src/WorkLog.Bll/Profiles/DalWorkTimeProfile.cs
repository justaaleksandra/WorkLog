using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;

namespace WorkLog.Bll.Profiles
{
    public class DalWorkTimeProfile : Profile
    {
        public DalWorkTimeProfile()
        {
            CreateMap<WorkTime, WorkTimeEntity>();
        }
    }
}
