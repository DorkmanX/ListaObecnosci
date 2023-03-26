using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DLL
{
    public class DBContext : DbContext
    {
        public DBContext() { }

        public virtual DbSet<StudentDTO> Users { get; set; }
        public virtual DbSet<GroupDTO> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-S4TPVIB;Initial Catalog=ListaObecnosciDB;User Id = sa; Password = sql_vwmp034;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //FOR LAPTOP "Server=DELLINSPIRON15;Initial Catalog=ListaObecnosciDB;User Id = sa; Password = uibrotho3421;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDTO>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(u => u.Id); //primary key

                //regular properties
                entity.Property(u => u.Id).HasColumnName("ID");
                entity.Property(u => u.Name).HasColumnName("Name");
                entity.Property(u => u.Surname).HasColumnName("Surname");
            });

            modelBuilder.Entity<GroupDTO>(entity =>
            {
                entity.ToTable("Groups");
                entity.HasKey(u => u.Id); //primary key
            });

            modelBuilder.Entity<CourseDTO>(entity =>
            {
                entity.ToTable("Courses");
                entity.HasKey(u => u.Id); //primary key

                //one to many relationship
                entity.HasOne(d => d.Teacher)
                .WithMany(u => u.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Course_Teacher_FK");
            });

            modelBuilder.Entity<TeacherDTO>(entity =>
            {
                entity.ToTable("Teachers");
                entity.HasKey(u => u.Id); //primary key
            });

            //many to many relationship
            modelBuilder.Entity<StudentDTO>()
            .HasMany(u => u.Groups)
            .WithMany(g => g.Students)
            .UsingEntity(e => e.ToTable("GroupsUsers"));
        }
    }
}
/*
ONE-TO-MANY RELATIONSHIP
entity.HasOne(d => d.User)
.WithMany(u => u.DevicesList)
.HasForeignKey(d => d.OwnerId)
.OnDelete(DeleteBehavior.Cascade)
.HasConstraintName("Devices_FK");
*/

/*
entity.HasIndex(u => u.Surname).HasDatabaseName("Login_idx").IsUnique(); //unique index
.IsRequired().HasMaxLength(32).IsUnique
entity.HasIndex(e => new { e.LineId, e.ModelGroupId }).HasName("IX_Cycle").IsUnique();
.ValueGeneratedOnAdd(); to jest do intentity
modelBuilder.Entity<Student>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("GETDATE()");
entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.DeliveryAlertRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("DeliveryAlert_User_ID_fk_3");
*/
