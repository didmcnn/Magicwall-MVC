using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

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
}