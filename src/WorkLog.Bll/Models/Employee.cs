using System;
using System.Collections.Generic;
using System.Text;

namespace WorkLog.Bll.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid InternalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal HourlyWage { get; set; }
    }
}
