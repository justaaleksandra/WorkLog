using System;

namespace WorkLog.Dal.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
