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
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<EmployeeEntity> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<EmployeeEntity> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _employeeRepository.Find();
            
            return _mapper.Map<List<Employee>>(employees);
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var employee = await _employeeRepository.Find(id);
            
            return _mapper.Map<Employee>(employee);
        }

        public async Task<Guid> AddEmployee(Employee employee)
        {
            var employeeEntity = _mapper.Map<EmployeeEntity>(employee);
            var employeeId = await _employeeRepository.Add(employeeEntity);
            await _employeeRepository.SaveChanges();
            
            return employeeId;
        }

        //public async Task UpdateEmployee(Guid id, )
    }
}
