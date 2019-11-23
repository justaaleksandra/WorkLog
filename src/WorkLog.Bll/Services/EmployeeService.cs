using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        public async Task<Employee> GetEmployee(Employee employee)
        {
            var employeeEntity = await _employeeRepository.Find(employee.Id);
            
            return _mapper.Map<Employee>(employeeEntity);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeEntity = _mapper.Map<EmployeeEntity>(employee);
            var employeeId = await _employeeRepository.Add(employeeEntity);
            await _employeeRepository.SaveChanges();
            
            return await GetEmployee(employee);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = await GetEmployee(employee);
            var employeeEntity = _mapper.Map<EmployeeEntity>(employeeToUpdate);
            _employeeRepository.Update(employeeEntity);
            var employeeChange = await _employeeRepository.SaveChanges();

            return await GetEmployee(employee);
        }

        public async Task<List<Employee>> RemoveEmployee(Employee employee)
        {
            var employeeToRemove = await GetEmployee(employee);
            var employeeEntity = _mapper.Map<EmployeeEntity>(employeeToRemove);
            _employeeRepository.Remove(employeeEntity);
            await _employeeRepository.SaveChanges();

            return await GetEmployees();
        }
    }
}
