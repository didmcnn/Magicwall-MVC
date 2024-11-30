using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace DataAccessLayer.Concrete;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{

    public virtual DbSet<About> Abouts { get; set; }
    public virtual DbSet<BankAccount> BankAccounts { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
    public virtual DbSet<DocumentsPageItem> DocumentsPageItems { get; set; }
    public virtual DbSet<JobApplication> JobApplications { get; set; }
    public virtual DbSet<ModelPageItem> ModelPageItems { get; set; }
    public virtual DbSet<OpenPosition> OpenPositions { get; set; }
    public virtual DbSet<PhotoPageItem> PhotoPageItems { get; set; }
    public virtual DbSet<ReferencesPageItem> ReferencesPageItems { get; set; }
    public virtual DbSet<VideoPageItem> VideoPageItems { get; set; }
    public virtual DbSet<Catalog> Catalogs { get; set; }
    public virtual DbSet<HomePageItem> HomePageItems { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ModelDetail> ModelDetails { get; set; }
    public virtual DbSet<ModelImage> ModelImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModelPageItem>()
            .HasOne(mpi => mpi.Details)
            .WithOne(md => md.ModelPageItem)
            .HasForeignKey<ModelDetail>(md => md.ModelPageItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ModelDetail>()
            .HasMany(md => md.ModelImages)
            .WithOne(mi => mi.ModelDetail)
            .HasForeignKey(mi => mi.ModelDetailId)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<ModelImage>()
            .HasOne(mi => mi.ModelDetail)
            .WithMany(md => md.ModelImages)
            .HasForeignKey(mi => mi.ModelDetailId)
            .OnDelete(DeleteBehavior.NoAction); 

        // Create a default admin user
        var adminUser = new User
        {
            Id = 1,
            Username = "admin",
            Email = "admin@magicwall.com",
            PasswordHash = HashPassword("MagicWall24Admin@Pass!"),
            CreatedDate = DateTime.UtcNow
        };

        modelBuilder.Entity<User>().HasData(adminUser);
        // Additional configurations if needed
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(); // Ensure unique emails

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    // Helper method to hash passwords
    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}