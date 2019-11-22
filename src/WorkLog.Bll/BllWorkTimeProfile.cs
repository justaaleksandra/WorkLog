using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;

namespace WorkLog.Bll
{
    public class BllWorkTimeProfile : Profile
    {
        public BllWorkTimeProfile()
        {
            CreateMap<WorkTimeEntity, WorkTime>();
        }
    }
}
