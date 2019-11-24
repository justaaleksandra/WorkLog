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
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTimeController : Controller
    {
        private readonly IWorkTimeService _workTimeService;
        private readonly IEmployeeService _employeeService;


        public WorkTimeController(IWorkTimeService workTimeService, IEmployeeService employeeService)
        {
            _workTimeService = workTimeService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkTimes()
        {
            var workTimes = await _workTimeService.GetWorkTimes();
            return Json(workTimes);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetWorkTime(Guid employeeId)
        {
            var employee = await _employeeService.GetEmployee(employeeId);
            var workTime = new WorkTime();
            if (employee.Id != Guid.Empty)
            {
                workTime = await _workTimeService.GetEmployeeWorkTime(employee);
            }

            return Json(workTime);
        }

        [HttpPost]
        //public async Task<IActionResult> AddWorkTime(WorkTime workTimeToAdd, Guid employeeId)
        public async Task<IActionResult> AddWorkTime(WorkTime workTime)
        {
            var employee = await _employeeService.GetEmployee(workTime.EmployeeId);

            workTime.EmployeeId = employee.Id;
            workTime.HourlyWage = employee.HourlyWage;
            workTime.ActualWage = employee.HourlyWage;
            
            var newEmployeeNewId = await _workTimeService.AddEmployeeWorkTime(workTime);

            return Json(newEmployeeNewId);
        }

        [HttpPut("{employeeId}")]
        //public async Task<IActionResult> UpdateEmployee(Employee employee)
        public async Task<IActionResult> UpdateEmployee(Guid employeeId)
        {
            var employeeHoursUpdated = await _workTimeService.UpdateEmployeeWorkTime(employeeId);

            return Json(employeeHoursUpdated);
        }

        [HttpDelete("{employeeId}")]
        //public async Task<IActionResult> RemoveWorkTime(Guid workTimeId, Guid employeeId)
        public async Task<IActionResult> RemoveWorkTime(Guid employeeId)
        {
            var employee = await _employeeService.GetEmployee(employeeId);
            var workTimes = await _workTimeService.RemoveEmployeeWorkTime(employee);

            return Json(workTimes);
        }
    }
}
