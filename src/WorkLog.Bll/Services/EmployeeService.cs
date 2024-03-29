﻿using System;
using System.Collections.Generic;
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

        public async Task<IList<Employee>> GetEmployees()
        {
            var employeesEntity = await _employeeRepository.Find();
            
            return _mapper.Map<List<Employee>>(employeesEntity);
        }

        public async Task<Employee> GetEmployee(Guid employeeId)
        {
            var employeeEntity = await _employeeRepository.Find(employeeId);
            
            return _mapper.Map<Employee>(employeeEntity);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeEntity = _mapper.Map<EmployeeEntity>(employee);
            var employeeId = await _employeeRepository.Add(employeeEntity);

            await _employeeRepository.SaveChanges();
            
            return await GetEmployee(employee.Id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeEntity = await _employeeRepository.Find(employee.Id);
            employeeEntity.HourlyWage = employee.HourlyWage+5;

            _employeeRepository.Update(employeeEntity);
            var employeeChange = await _employeeRepository.SaveChanges();

            return await GetEmployee(employee.Id);
        }

        public async Task<IList<Employee>> RemoveEmployee(Guid employeeId)
        {
            var employeeEntity = await _employeeRepository.Find(employeeId);

            _employeeRepository.Remove(employeeEntity);
            await _employeeRepository.SaveChanges();

            return await GetEmployees();
        }

        public async Task<int> GetNumberOfEmployees()
        {
            var employees = await _employeeRepository.Find();

            return employees.Count;
        }

        public async Task<int> GetNextValidIdForEmployee()
        {
            var employees = await _employeeRepository.Find();

            return employees.Count + 1;
        }
    }
}
