using DataHUBWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHUBWebApplication.Data;

public class DataHubContext : DbContext
{
    public DataHubContext(DbContextOptions<DataHubContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Materials> Materials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}