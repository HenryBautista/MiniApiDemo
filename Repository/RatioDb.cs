using Microsoft.EntityFrameworkCore;
using MinApiDemo.Models;

namespace MinApiDemo.Repository;

public class RatioDb : DbContext
{
    public RatioDb(DbContextOptions options) : base (options) {}
    public DbSet<Ratio> Ratios { get; set; } = null!;

    //Seed default data
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Ratio>().HasData(
            new Ratio { Id = 1, LowerBound = 1000, UpperBound = 3000, Value = 0.5m },
            new Ratio { Id = 2, LowerBound = 4000, UpperBound = 5000, Value = 0.8m },
            new Ratio { Id = 3, LowerBound = 6000, UpperBound = 7000, Value = 1.5m },
            new Ratio { Id = 4, LowerBound = 8000, UpperBound = 9000, Value = 2.5m }
        );
    }

}