using _2035Cars_Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Database
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }


        public CarDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting Value Objects
            modelBuilder.Entity<Car>().OwnsOne(o => o.Equipment);

            modelBuilder.Entity<Client>().OwnsOne(o => o.Person);

            modelBuilder.Entity<Employee>().OwnsOne(o => o.Address);
            modelBuilder.Entity<Employee>().OwnsOne(o => o.Account);
            modelBuilder.Entity<Employee>().OwnsOne(o => o.Person);

            modelBuilder.Entity<Rental>().OwnsOne(o => o.Address);

            // Setting Relations beetwen entities
            modelBuilder.Entity<Car>().HasOne(p => p.Rental).WithMany(p => p.Cars);
            modelBuilder.Entity<Employee>().HasOne(p => p.Rental).WithMany(p => p.Employees);
        
            // modelBuilder.Entity<Order>().HasOne(x => x.FromRental)
            //                             .HasForeignKey(x => x.FromRentalId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.LastUpdateDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdateDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}