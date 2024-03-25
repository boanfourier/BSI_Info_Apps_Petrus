using Microsoft.EntityFrameworkCore;
using BSI_Info_APIService_Domain;

namespace BSI_Info_APIService_Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Events> Events { get; set; }
    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasMany(d => d.Usernames).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersRole",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersRoles_Users"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersRoles_Roles"),
                    j =>
                    {
                        j.HasKey("RoleId", "Username");
                        j.ToTable("UsersRoles");
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                        j.IndexerProperty<string>("Username").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.LastLogin).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MaxAttempt).HasDefaultValue((byte)5);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
