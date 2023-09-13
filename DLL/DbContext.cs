using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DLL
{
    public class DBContext : DbContext
    {
        public DBContext() { }

        public virtual DbSet<StudentDTO> Students { get; set; }
        public virtual DbSet<GroupDTO> Groups { get; set; }
        public virtual DbSet<CourseDTO> Courses { get; set; }
        public virtual DbSet<LessonDTO> Lessons { get; set; }
        public virtual DbSet<TeacherDTO> Teachers { get; set; }
        public virtual DbSet<TimesheetDTO> Timesheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=ListaObecnosciDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                //FOR DESKTOP "Server=DESKTOP-S4TPVIB;Initial Catalog=ListaObecnosciDB;User Id = sa; Password = sql_vwmp034;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                //FOR LAPTOP "Server=DELLINSPIRON15;Initial Catalog=ListaObecnosciDB;User Id = sa; Password = uibrotho3421;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                //FOR COMPANY LAPTOP "Server=localhost;Database=ListaObecnosciDB;Trusted_Connection=False;User Id = sa; Password= uibrotho3421; Persist Security Info=True;"
                //dotnet ef migrations add DatabaseV1
                //dotnet ef database update
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDTO>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(d => d.Id);

                entity.Property(u => u.Id).HasColumnName("ID");
                entity.Property(u => u.Name).HasColumnName("Name");
                entity.Property(u => u.Surname).HasColumnName("Surname");
            });

            modelBuilder.Entity<GroupDTO>(entity =>
            {
                entity.ToTable("Groups");
                entity.HasKey(d => d.Id);

                entity.HasOne(d => d.Teacher)
                .WithMany(u => u.Groups)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Group_Teacher_FK");
            });

            modelBuilder.Entity<CourseDTO>(entity =>
            {
                entity.ToTable("Courses");
                entity.HasKey(d => d.Id);

                entity.HasOne(d => d.Teacher)
                .WithMany(u => u.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Course_Teacher_FK");

                entity.HasOne(d => d.Group)
                .WithMany(u => u.Courses)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Course_Group_FK");
            });

            modelBuilder.Entity<TeacherDTO>(entity =>
            {
                entity.ToTable("Teachers");
                entity.HasKey(d => d.Id);
            });

            modelBuilder.Entity<TimesheetDTO>(entity =>
            {
                entity.ToTable("Timesheets");
                entity.HasKey(d => d.Id);

                entity.HasOne(d => d.Student)
                .WithMany(u => u.Timesheets)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Timesheet_Student_FK");
            });

            modelBuilder.Entity<LessonDTO>(entity =>
            {
                entity.ToTable("Lessons");
                entity.HasKey(d => d.Id);

                entity.HasOne(d => d.Course)
                .WithMany(u => u.Lessons)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Lesson_Group_FK");
            });

            modelBuilder.Entity<MarkDTO>(entity =>
            {
                entity.ToTable("Marks");
                entity.HasKey(d => d.Id);

                entity.HasOne(d => d.Student)
                .WithMany(u => u.Marks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Marks_Student_FK");

                 entity.HasOne(d => d.Course)
                .WithMany(u => u.Marks)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Marks_Course_FK");

                 entity.HasOne(d => d.Group)
                .WithMany(u => u.Marks)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Marks_Group_FK");
            });

            modelBuilder.Entity<StudentDTO>()
            .HasMany(u => u.Groups)
            .WithMany(g => g.Students)
            .UsingEntity(e => e.ToTable("GroupsUsers"));
        }
    }
}

//dotnet ef migrations add DatabaseV1
//dotnet ef database update
