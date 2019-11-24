using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkLog.Bll.Models;
using WorkLog.Bll.Services;

namespace WorkLog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            return Json(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var employee = await _employeeService.GetEmployee(employeeId);

            return Json(employee);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetNumberOfEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            var numberOfEmployees = employees.Count;

            return Json(numberOfEmployees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employeeToAdd)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                InternalId = await _employeeService.GetNextValidIdForEmployee(),
                FirstName = employeeToAdd.FirstName,
                LastName = employeeToAdd.LastName,
                Position = employeeToAdd.Position,
                HourlyWage = employeeToAdd.HourlyWage,
            };
            var employeeId = await _employeeService.AddEmployee(employee);

            return Json(employeeId);
        }

        [HttpPut("UpdateHourlyWage")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var employeeUpdated = await _employeeService.UpdateEmployee(employee);

            return Json(employeeUpdated);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> RemoveEmployee(Guid employeeId)
        {
            var employees = await _employeeService.RemoveEmployee(employeeId);

            return Json(employees);
        }
    }
}
