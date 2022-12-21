using Microsoft.EntityFrameworkCore;

namespace Blazornew.Data;

public class ApplicationContext : DbContext
{
    //  public DbSet<User> Users => Set<User>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Tag> Tags => Set<Tag>();

    //  public DbSet<top10> Top10s => Set<top10>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("server=localhost;Port=5432;database=Semen;userId=postgres;password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>().HasMany(m => m.top10)
            .WithMany();
    }
}
