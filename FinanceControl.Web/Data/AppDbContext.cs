using FinanceControl.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Web.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define the schema with 'public' for all entities
        modelBuilder.Entity<Account>().ToTable("Accounts", "public");
        modelBuilder.Entity<Entry>().ToTable("Entries", "public");   
        modelBuilder.Entity<User>().ToTable("Users", "public");   
    }
}