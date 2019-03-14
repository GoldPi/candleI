using System;
using System.Collections.Generic;

namespace EntityModel
{
    public class CommentThread : IEntity<string>
    {
        public string Id { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdateOn { get ; set ; }
        public string CreatedByUserId { get ; set ; }
        public string UpdateByUserId { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public string Title { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
