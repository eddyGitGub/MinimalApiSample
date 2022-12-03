using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SocialDbContext : DbContext
{
    public SocialDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
}
