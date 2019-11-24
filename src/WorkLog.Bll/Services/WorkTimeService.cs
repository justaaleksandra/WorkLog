using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
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

        public async Task<WorkTime> GetEmployeeWorkTime(Employee employee)
        {
            var employeeEntity = await _employeeRepository.Find(employee.Id);
            var workTimesEntity = await _workTimRepository.Find();
            var workTime = workTimesEntity.ToList().Find(wt => wt.EmployeeId == employeeEntity.Id);

            return _mapper.Map<WorkTime>(workTime);
        }

        public async Task<WorkTime> AddEmployeeWorkTime(WorkTime workTime)
        {
            var workTimeEntity = _mapper.Map<WorkTimeEntity>(workTime);
            var workTimeId = await _workTimRepository.Add(workTimeEntity);
            await _workTimRepository.SaveChanges();

            var employeesEntity = await _employeeRepository.Find();
            var employeeEntity = employeesEntity.ToList().Find(e => e.Id == workTime.EmployeeId);
            var employee = _mapper.Map<Employee>(employeeEntity);

            return await GetEmployeeWorkTime(employee);
        }
        public async Task<WorkTime> UpdateEmployeeWorkTime(Guid employeeId)
        {
            var employeeEntity = await _employeeRepository.Find(employeeId);
            var workTimesEntity = await _workTimRepository.Find();
            var workTimeEntity = workTimesEntity.ToList().Find(wt => wt.EmployeeId == employeeEntity.Id);
;
            workTimeEntity.Hours = workTimeEntity.Hours + TimeSpan.FromHours(1);

            _workTimRepository.Update(workTimeEntity);
            var employeeChange = await _employeeRepository.SaveChanges();

            var employee = _mapper.Map<Employee>(employeeEntity);

            return await GetEmployeeWorkTime(employee);
        }

        public async Task<IList<WorkTime>> RemoveEmployeeWorkTime(Employee employee)
        {
            var employeeEntity = await _employeeRepository.Find(employee.Id);
            var workTimesEntity = await _workTimRepository.Find();
            var workTimeEntity = workTimesEntity.ToList().Find(wt => wt.EmployeeId == employeeEntity.Id);

            _workTimRepository.Remove(workTimeEntity);
            await _workTimRepository.SaveChanges();

            return await GetWorkTimes();
        }
    }
}
