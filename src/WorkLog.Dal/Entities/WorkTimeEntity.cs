﻿using System;

namespace WorkLog.Dal.Entities
{
    public class WorkTimeEntity : IEntity
    {
        public Guid Id { get; set; }
        public TimeSpan Hours { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public decimal HourlyWage { get; set; }
        public decimal ActualWage { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
    }
}
