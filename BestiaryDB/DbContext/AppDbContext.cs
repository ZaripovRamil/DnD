using Microsoft.EntityFrameworkCore;
using Models.GameModel;

namespace BestiaryDB.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) => Database.EnsureCreated();
    public DbSet<Entity> Entities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var monsters = new Entity[]
        {
            new(1, "Firenewt warlock of Imix", 33, 10, 1,
                3, 8, 6, 6),
            new(2, "Swarm of ravens", 24, 12, 4,
                0, 8, 1, 2),
            new(3, "Enormous Tentacle", 60, 12, 1,
                2, 12, 8, 8)
        };
        modelBuilder.Entity<Entity>().HasData(monsters);
    }
}