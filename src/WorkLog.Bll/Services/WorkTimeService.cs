using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WorkLog.Dal.Entities;
using WorkLog.Dal.Repositories;

namespace WorkLog.Bll.Services
{
    public class WorkTimeService : IWorkTimeService
    {
        private readonly IRepository<WorkTimeEntity> _workTimRepository;
        private readonly IMapper _mapper;

        public WorkTimeService(IRepository<WorkTimeEntity> workTimRepository, IMapper mapper)
        {
            _workTimRepository = workTimRepository;
            _mapper = mapper;
        }
    }
}
