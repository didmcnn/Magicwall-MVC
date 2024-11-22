using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DataAccessLayer.Concrete;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=37.148.210.105;Initial Catalog=testdb; User Id=site;Password=kv84EtFBboaok2e1;Connect Timeout=15;Encrypt=False;Packet Size=4096");
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<DocumentsPageItem> DocumentsPageItems { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<ModelPageItem> ModelPageItems { get; set; }
    public DbSet<OpenPosition> OpenPositions { get; set; }
    public DbSet<PhotoPageItem> PhotoPageItems { get; set; }
    public DbSet<ReferencesPageItem> ReferencesPageItems { get; set; }
    public DbSet<VideoPageItem> VideoPageItems { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<HomePageItem> HomePageItems { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Create a default admin user
        var adminUser = new User
        {
            Username = "admin",
            Email = "admin@magicwall.com",
            PasswordHash = HashPassword("MagicWall24Admin@Pass!"),
            CreatedDate = DateTime.UtcNow
        };

        modelBuilder.Entity<User>().HasData(adminUser);
        // Additional configurations if needed
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(); // Ensure unique emails
    }
    // Helper method to hash passwords
    private static string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}