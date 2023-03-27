using Microsoft.EntityFrameworkCore;
using MinApiDemo.Models;

namespace MinApiDemo.Repository;

public class RatioDb : DbContext
{
    public RatioDb(DbContextOptions options) : base (options) {}
    public DbSet<Ratio> Ratios { get; set; } = null!;

}