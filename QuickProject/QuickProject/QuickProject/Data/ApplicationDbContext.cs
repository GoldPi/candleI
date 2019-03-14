using System;
using System.Collections.Generic;
using System.Text;
using EntityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuickProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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
    }
}
