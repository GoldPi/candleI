using System;

namespace EntityModel
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime UpdateOn { get; set; }
        string CreatedByUserId { get; set; }
        string UpdateByUserId { get; set; }
        bool IsDeleted { get; set; }
    }
}
