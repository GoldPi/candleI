using System;

namespace EntityModel
{
    public class Comment : IEntity<string>
    {
        public string Id { get ; set ; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime UpdateOn { get ; set ; }
        public string CreatedByUserId { get ; set ; }
        public string UpdateByUserId { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public string CommentThreadId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public CommentThread CommentThread { get; set; }
    }
}
