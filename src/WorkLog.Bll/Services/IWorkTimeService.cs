using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkLog.Bll.Models;

namespace WorkLog.Bll.Services
{
    public interface IWorkTimeService
    {
        Task<IList<WorkTime>> GetWorkTimes();
        Task<WorkTime> GetEmployeeWorkTime(Employee employee);
        Task<WorkTime> AddEmployeeWorkTime(WorkTime workTime);
        Task<WorkTime> UpdateEmployeeWorkTime(Guid employeeId);
        Task<IList<WorkTime>> RemoveEmployeeWorkTime(Employee employeeId);
    }
}
