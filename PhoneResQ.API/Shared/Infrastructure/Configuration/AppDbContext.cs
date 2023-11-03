using Microsoft.EntityFrameworkCore;
using PhoneResQ.API.Shared.Infrastructure.Configuration.Extensions;
using PhoneResQ.API.Support.Domain.Models.Entities;

namespace PhoneResQ.API.Shared.Infrastructure.Configuration
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
            // Initialize table
            #region Customer
            modelBuilder.Entity<Customer>().ToTable("Customers");
            // Initialize primary key
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            // Initialize properties
            modelBuilder.Entity<Customer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Customer>().Property(c => c.DNI).IsRequired().HasMaxLength(8);
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(32);
            modelBuilder.Entity<Customer>().Property(c => c.Phone).HasMaxLength(12);
            modelBuilder.Entity<Customer>().Property(c => c.Password).IsRequired().HasMaxLength(16);
            #endregion

            // Relationship with other tables
            modelBuilder.Entity<Customer>().HasMany(c => c.Devices)
                                           .WithOne(d => d.Owner)
                                           .HasForeignKey(d => d.OwnerId);

            #region Device
            modelBuilder.Entity<Device>().ToTable("Devices");
            modelBuilder.Entity<Device>().HasKey(d => d.Id);
            modelBuilder.Entity<Device>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Device>().Property(d => d.IMEI).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Device>().Property(d => d.Brand).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Device>().Property(d => d.Model).IsRequired().HasMaxLength(20);
            #endregion

            modelBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
