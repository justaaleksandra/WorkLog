using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkLog.Dal.Entities;

namespace WorkLog.Dal
{
    public class WorkLogContext : DbContext
    {
        public WorkLogContext(DbContextOptions<WorkLogContext> options) : base(options)
        {
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<WorkTimeEntity> WorkingTimes { get; set; }
    }

}
