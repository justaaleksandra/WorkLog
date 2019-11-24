using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkLog.Bll.Models;
using WorkLog.Bll.Services;

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
        public async Task<IActionResult> AddWorkTime([FromBody]WorkTime workTime)
        {
            var employee = await _employeeService.GetEmployee(workTime.EmployeeId);

            workTime.HourlyWage = employee.HourlyWage;
            workTime.ActualWage = employee.HourlyWage;
            
            var newEmployeeNewId = await _workTimeService.AddEmployeeWorkTime(workTime);

            return Json(newEmployeeNewId);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId)
        {
            var employeeHoursUpdated = await _workTimeService.UpdateEmployeeWorkTime(employeeId);

            return Json(employeeHoursUpdated);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> RemoveWorkTime(Guid employeeId)
        {
            var employee = await _employeeService.GetEmployee(employeeId);
            var workTimes = await _workTimeService.RemoveEmployeeWorkTime(employee);

            return Json(workTimes);
        }
    }
}
