using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;

namespace WorkLog.Bll.Profiles
{
    public class BllWorkTimeProfile : Profile
    {
        public BllWorkTimeProfile()
        {
            CreateMap<WorkTimeEntity, WorkTime>();
        }
    }
}
