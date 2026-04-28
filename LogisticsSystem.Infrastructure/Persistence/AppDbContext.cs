using LogisticsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Load> Loads => Set<Load>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<DriverLoadRequest> DriverLoadRequests => Set<DriverLoadRequest>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Warehouse)
                .WithMany(w => w.Drivers)
                .HasForeignKey(d => d.WarehouseId);
        }
    }
}