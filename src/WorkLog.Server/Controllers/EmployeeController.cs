using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> AddEmployee(Employee employeeToAdd) // add parameters
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

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId) // add parameters
        {
            var employee = await _employeeService.GetEmployee(employeeId);

            var employeeUpdated = await _employeeService.UpdateEmployee(employeeId);

            return Json(employeeUpdated);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> RemoveEmployee(Guid employeeId)
        {
            var Employees = await _employeeService.RemoveEmployee(employeeId);

            return Json(Employees);
        }


        [HttpPut("updateEmployeeInternalId")]
        public async Task<IActionResult> UpdateEmployee()
        {
            var employees = await _employeeService.GetEmployees();
            var sortedEmployees = employees.OrderBy(e => e.InternalId);
            var count = await _employeeService.GetNumberOfEmployees();
            var i = 1;

            foreach (var employee in sortedEmployees)
            {
                employee.InternalId = i;
                i++
            }


            return Json(sortedEmployees);
        }
    }
}
