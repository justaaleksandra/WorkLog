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
            employeeService = _employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            return Json(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders(Guid id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return Json(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee()
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                InternalId = Guid.NewGuid(),
                FirstName = "Dario",
                LastName = "Sulak",

            }
        }
    }
}
