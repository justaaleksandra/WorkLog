using System;
using System.Collections.Generic;
using System.Text;

namespace WorkLog.Dal.Entities
{
    public class EmployeeEntity : IEntity
    {
        public Guid Id { get; set; }
        public int InternalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal HourlyWage { get; set; }

        public ICollection<WorkTimeEntity> WorkTimes { get; set; }
    }
}
