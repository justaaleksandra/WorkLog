using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkLog.Bll.Models;

namespace WorkLog.Bll.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<List<Employee>> RemoveEmployee(Employee employee);


    }
}
