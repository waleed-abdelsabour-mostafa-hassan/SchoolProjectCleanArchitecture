using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrastructure.Context
{
    //IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<InstructorSubject> instructorSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Composite Keys
            modelBuilder.Entity<DepartmentSubject>()
                .HasKey(x => new { x.DepartmentId, x.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasKey(x => new { x.StudentId, x.SubjectId });

            modelBuilder.Entity<InstructorSubject>()
                .HasKey(x => new { x.InstructorId, x.SubjectId });
            #endregion

            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.Supervisor)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(x => x.Id);
                //entity.Property(x => x.NameAr).HasMaxLength(200);
                //entity.Property(x => x.NameEn).HasMaxLength(200);

                entity.HasMany(x => x.Students)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Instructor)
                .WithOne(x => x.DepartmentManager)
                .HasForeignKey<Department>(x => x.InstManagerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DepartmentSubject>(entity =>
            {
                entity.HasOne(ds => ds.Department)
                .WithMany(d => d.DepartmentSubjects)
                .HasForeignKey(ds => ds.DepartmentId);

                entity.HasOne(ds => ds.Subject)
                .WithMany(s => s.DepartmentSubjects)
                .HasForeignKey(ds => ds.SubjectId);

            });

            modelBuilder.Entity<InstructorSubject>(entity =>
            {
                entity.HasOne(ds => ds.Instructor)
                .WithMany(d => d.InstructorSubjects)
                .HasForeignKey(ds => ds.InstructorId);

                entity.HasOne(ds => ds.Subject)
                .WithMany(s => s.InstructorSubjects)
                .HasForeignKey(ds => ds.SubjectId);

            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.HasOne(ds => ds.Student)
                .WithMany(d => d.StudentSubjects)
                .HasForeignKey(ds => ds.StudentId);

                entity.HasOne(ds => ds.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ds => ds.SubjectId);

            });





            base.OnModelCreating(modelBuilder);
        }


    }
}
