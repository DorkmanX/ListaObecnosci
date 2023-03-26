using DLL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DLL
{
    public class DBContext : DbContext
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public virtual DbSet<UserDTO> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DELLINSPIRON15; User Id = sa; Password = uibrotho3421; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>(entity =>
            {
                entity.ToTable("Users"); //table name

                entity.HasKey(u => u.Id).HasName("User_pk"); //primary key
                entity.HasIndex(u => u.Surname).HasDatabaseName("Login_idx").IsUnique(); //unique index

                //regular properties
                entity.Property(u => u.Id).HasColumnName("ID");
                entity.Property(u => u.Name).HasColumnName("Name").IsRequired();

                entity.HasOne(d => d.User)
                .WithMany(u => u.DevicesList)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Devices_FK");
            });
        }
    }
}
    /*
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
