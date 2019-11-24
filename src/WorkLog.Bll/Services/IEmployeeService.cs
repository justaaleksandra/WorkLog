using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkLog.Bll.Models;

namespace WorkLog.Bll.Services
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<IList<Employee>> RemoveEmployee(Guid employeeId);
        Task<int> GetNumberOfEmployees();
        Task<int> GetNextValidIdForEmployee();
    }
}
