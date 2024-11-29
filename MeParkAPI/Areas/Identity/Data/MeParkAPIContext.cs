using MeParkAPI.Areas.Identity.Data;
using MeParkAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeParkAPI.Areas.Identity.Data;

public class MeParkAPIContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Parking> Parkings { get; set; }
    public DbSet<ParkingSpace> ParkingSpaces { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<ParkingFee> ParkinsFeeds { get; set; }


    public MeParkAPIContext(DbContextOptions<MeParkAPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Owner)
            .WithMany(u => u.Vehicles)
            .HasForeignKey(v => v.IdOwner);

        modelBuilder.Entity<ParkingSpace>()
            .HasOne(p => p.Parking)
            .WithMany(p => p.ParkingSpaces)
            .HasForeignKey(p => p.IdParking);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Owner)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.IdOwer);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Space)
            .WithMany(p => p.Transactions)
            .HasForeignKey(t => t.IdSpace);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.ParkinsFees)
            .WithMany(f => f.Transactions)
            .HasForeignKey(t => t.IdFee);

    }
}
