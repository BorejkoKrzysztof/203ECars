using _2035Cars_Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Database;

public class CarsDbContext : DbContext
{
    public CarsDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
}