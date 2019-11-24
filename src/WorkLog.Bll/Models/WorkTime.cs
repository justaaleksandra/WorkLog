using System;

namespace WorkLog.Bll.Models
{
    public class WorkTime
    {
        public Guid Id { get; set; }
        public int Hours { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public decimal HourlyWage { get; set; }
        public decimal ActualWage { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
