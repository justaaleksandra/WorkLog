using System;
using System.Collections.Generic;
using System.Text;

namespace WorkLog.Bll.Models
{
    public class WorkTime
    {
        public Guid Id { get; set; }
        public DateTime Hours { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public decimal HourlyWage { get; set; }
        public decimal ActualWage { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
