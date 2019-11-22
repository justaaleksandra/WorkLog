using System;
using System.Collections.Generic;
using System.Text;

namespace WorkLog.Dal.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
