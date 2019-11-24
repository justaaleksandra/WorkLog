using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WorkLog.Bll.Models;
using WorkLog.Dal.Entities;
using WorkLog.Dal.Repositories;

namespace WorkLog.Bll.Services
{
    public class WorkTimeService : IWorkTimeService
    {
        private readonly IRepository<WorkTimeEntity> _workTimRepository;
        private readonly IRepository<EmployeeEntity> _employeeRepository;
        private readonly IMapper _mapper;

        public WorkTimeService(IRepository<WorkTimeEntity> workTimRepository, IRepository<EmployeeEntity> employeeRepository, IMapper mapper)
        {
            _workTimRepository = workTimRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IList<WorkTime>> GetWorkTimes()
        {
            var workTimeEntity = await _workTimRepository.Find();

            return _mapper.Map<List<WorkTime>>(workTimeEntity);
        }

        public async Task<WorkTime> GetEmployeeWorkTime(WorkTime workTime)
        {
            var workTimeEntity = await _workTimRepository.Find(workTime.Id);

            return _mapper.Map<WorkTime>(workTimeEntity);
        }

        public async Task<WorkTime> AddEmployeeWorkTime(WorkTime workTime)
        {
            var workTimeEntity = _mapper.Map<WorkTimeEntity>(workTime);
            var workTimeId = await _workTimRepository.Add(workTimeEntity);
            await _workTimRepository.SaveChanges();

            return await GetEmployeeWorkTime(workTime);
        }

        public async Task<IList<WorkTime>> RemoveEmployeeWorkTime(Guid workTimeId,Guid employeeId)
        {
            var employeeEntity = await _employeeRepository.Find(employeeId);

            if (employeeEntity.Id != Guid.Empty)
            {
                var workTimeEntity = await _workTimRepository.Find(workTimeId);
                _workTimRepository.Remove(workTimeEntity);
                await _workTimRepository.SaveChanges();
            }

            return await GetWorkTimes();
        }
    }
}
