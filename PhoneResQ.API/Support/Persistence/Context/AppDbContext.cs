using Microsoft.EntityFrameworkCore;
using PhoneResQ.API.Shared.Extensions;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Support.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<SupportCenter> SupportCenters { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<StatusUpdate> StatusUpdates { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();


            modelBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
