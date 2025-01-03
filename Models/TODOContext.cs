using Microsoft.EntityFrameworkCore;

namespace TODO.Models;

public class TODOContext:DbContext
{
    public TODOContext(DbContextOptions<TODOContext> options):base (options)
    {
        
    }

    public DbSet<TODO> TODOs { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Status> statuses { get; set; } = null!;
    //seed date
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category {CategoryID = "Coding",Name = "Coding"},
            new Category {CategoryID = "Home ",Name = "Home"},
            new Category {CategoryID = "ex ",Name = "Exercise"},
            new Category {CategoryID = "Shopping ",Name = "Shopping"},
            new Category {CategoryID = "university ",Name = "university"},
            new Category {CategoryID = "Work ",Name = "Work"}
            );
        modelBuilder.Entity<Status>().HasData(
            new Status {StatusID = "Open",Name = "Open"},
            new Status {StatusID = "Closed",Name = "Completed"}
            
        );
    }
}