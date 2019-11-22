using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace WorkLog.Dal.Entities
{
    public class WorkTimeEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Hours { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public decimal HourlyWage { get; set; }
        public decimal ActualWage { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
