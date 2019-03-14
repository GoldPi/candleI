using System;
using System.Text;

namespace EntityModel
{

    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdateOn { get ; set ; }
        public string CreatedByUserId { get ; set ; }
        public string UpdateByUserId { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public string CommentThreadId { get; set; }
        public CommentThread CommentThread { get; set; }
    }

}
