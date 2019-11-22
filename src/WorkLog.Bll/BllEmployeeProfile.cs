using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;

namespace WorkLog.Bll
{
    public class BllEmployeeProfile : Profile
    {
        public BllEmployeeProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
        }
    }
}
