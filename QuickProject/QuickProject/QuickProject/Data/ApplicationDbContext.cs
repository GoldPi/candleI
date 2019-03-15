using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuickProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        IHttpContextAccessor HttpContext;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor context)
            : base(options)
        {
            HttpContext = context;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<AcadamicYear> AcadamicYears { get; set; }
        public DbSet<AppliedCourse> AppliedCourses { get; set; }
        public DbSet<CommentThread> CommentThreads { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TenantProfile> TenantProfiles { get; set; }
        public DbSet<Transcation> Transcations { get; set; }

        public override int SaveChanges()
        {
            GetId();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            GetId();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void GetId()
        {
            var User = HttpContext.HttpContext.User.Identity.IsAuthenticated ? HttpContext.HttpContext.User.Identity.Name : "UnKnown";
            foreach (var id in ChangeTracker.Entries())
            {

                try
                {

                    var val = ((BaseEntity<string>)id.Entity);
                    if (id.State == EntityState.Added)
                    {

                        val.Id = Guid.NewGuid().ToString();
                        val.CreatedByUserId = User;
                        val.CreatedOn = DateTime.UtcNow;
                        val.UpdateByUserId = val.CreatedByUserId;
                        val.UpdateOn = val.CreatedOn;
                        val.IsDeleted = false;
                        
                       
                    }
                    if (id.State == EntityState.Modified)
                    {
                        Entry(val).Property(i => i.CommentThreadId).IsModified = false;
                        Entry(val).Property(i => i.CreatedByUserId).IsModified = false;
                        Entry(val).Property(i => i.CreatedOn).IsModified = false;
                        Entry(val).Property(i => i.IsDeleted).IsModified = false;
                        val.UpdateByUserId = User;
                        val.UpdateOn = DateTime.UtcNow;
                       
                     
                       
                    }
                    //Console.Clear();
                    Console.WriteLine($"Entity {id.Entity.GetType()} => {id.State} => {val.Id} on {val.UpdateOn}");
                }
                catch
                {
                    Console.WriteLine($"Entity {id.Entity.GetType()} => {id.State}");
                }
                
            }
        }
    }
}
