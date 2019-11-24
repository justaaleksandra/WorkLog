using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkLog.Bll.Models;
using WorkLog.Bll.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkLog.Server.Controllers
{
    public class WorkTimeController : Controller
    {
        private readonly IWorkTimeService _workTimeService;
        private readonly IEmployeeService _employeeService;


        public WorkTimeController(IWorkTimeService workTimeService, IEmployeeService employeeService)
        {
            _workTimeService = workTimeService;
            _employeeService = employeeService;
        }

        [HttpGet("work")]
        public async Task<IActionResult> GetWorkTimes()
        {
            var workTimes = await _workTimeService.GetWorkTimes();
            return Json(workTimes);
        }

        [HttpGet("work/{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var employee = await _employeeService.GetEmployee(employeeId);
            return Json(employee);
        }

        [HttpGet("work/{workTime}")]
        public async Task<IActionResult> GetEmployee(WorkTime workTime)
        {
            var employeeWorkTime = await _workTimeService.GetEmployeeWorkTime(workTime);
            return Json(employeeWorkTime);
        }

        [HttpPost("work/{employeeId}")]
        public async Task<IActionResult> AddEmployee(WorkTime workTimeToAdd, Guid employeeId)
        {
            var employee = await _employeeService.GetEmployee(employeeId);

            var workTime = new WorkTime()
            {
                Id = Guid.NewGuid(),
                Hours = workTimeToAdd.Hours,
                HourlyWage = employee.HourlyWage,
                ActualWage = employee.HourlyWage,
                CreatedOnUtc = DateTime.UtcNow
            };
            var newEmployeeNewId = await _workTimeService.AddEmployeeWorkTime(workTime);

            return Json(newEmployeeNewId);
        }

        [HttpDelete("work/{workTimeId}/{employeeId}")]
        public async Task<IActionResult> RemoveEmployeeWorkTime(Guid workTimeId, Guid employeeId)
        {
            var workTimes = await _workTimeService.RemoveEmployeeWorkTime(workTimeId, employeeId);

            return Json(workTimes);
        }
    }
}
