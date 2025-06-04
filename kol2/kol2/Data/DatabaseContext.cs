using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Washing_Machine> WashingMachines { get; set; }
    public DbSet<ProgramEntity> Programs { get; set; }
    public DbSet<Available_Program> AvailablePrograms { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Purchase_History> PurchaseHistories { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Washing_Machine>(wm =>
        {
            wm.ToTable("Washing_Machine");

            wm.HasKey(e => e.WashingMachineId);
            wm.Property(e => e.MaxWeight).HasColumnType("decimal(10,2)");
            wm.Property(e => e.SerialNumber).HasMaxLength(100);
        });

        modelBuilder.Entity<ProgramEntity>(p =>
        {
            p.ToTable("Program");

            p.HasKey(e => e.ProgramId);
            p.Property(e => e.Name).HasMaxLength(50);
            p.Property(e => e.DurationMinutes);
            p.Property(e => e.TemperatureCelsius);
        });

        modelBuilder.Entity<Customer>(c =>
        {
            c.ToTable("Customer");

            c.HasKey(e => e.CustomerId);
            c.Property(e => e.FirstName).HasMaxLength(50);
            c.Property(e => e.LastName).HasMaxLength(100);
            c.Property(e => e.PhoneNumber).HasMaxLength(100);
        });

        modelBuilder.Entity<Available_Program>(ap =>
        {
            ap.ToTable("Available_Program");

            ap.HasKey(e => e.AvailableProgramId);
            ap.Property(e => e.WashingMachineId);
            ap.Property(e => e.ProgramId);
            ap.Property(e => e.Price).HasColumnType("decimal(10,2)");
        });

        modelBuilder.Entity<Purchase_History>(ph =>
        {
            ph.ToTable("Purchase_History");

            ph.HasKey(e => new { e.AvailableProgramId, e.CustomerId });
            ph.Property(e => e.PurchaseDate).HasColumnType("datetime");
            ph.Property(e => e.Rating);
        });

        modelBuilder.Entity<Washing_Machine>().HasData(new List<Washing_Machine>()
        {
            new Washing_Machine() { WashingMachineId = 1, MaxWeight = 20, SerialNumber = "abcd" },
            new Washing_Machine() { WashingMachineId = 2, MaxWeight = 30, SerialNumber = "dafa" },
            new Washing_Machine() { WashingMachineId = 3, MaxWeight = 40, SerialNumber = "iorem" }
        });

        modelBuilder.Entity<ProgramEntity>().HasData(new List<ProgramEntity>()
        {
            new ProgramEntity() { ProgramId = 1, Name = "Program1", DurationMinutes = 60, TemperatureCelsius = 60 },
            new ProgramEntity() { ProgramId = 2, Name = "Program2", DurationMinutes = 40, TemperatureCelsius = 30 },
            new ProgramEntity() { ProgramId = 3, Name = "Program3", DurationMinutes = 30, TemperatureCelsius = 20 }
        });

        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer() { CustomerId = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "123456789" },
            new Customer() { CustomerId = 2, FirstName = "Jane", LastName = "Doe", PhoneNumber = "987654321" }
        });

        modelBuilder.Entity<Available_Program>().HasData(new List<Available_Program>()
        {
            new Available_Program() { AvailableProgramId = 1, WashingMachineId = 2, ProgramId = 1, Price = 20 },
            new Available_Program() { AvailableProgramId = 2, WashingMachineId = 1, ProgramId = 3, Price = 40 }
        });

        modelBuilder.Entity<Purchase_History>().HasData(new List<Purchase_History>()
        {
            new Purchase_History()
                { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2021-09-01"), Rating = 5 },
            new Purchase_History()
                { AvailableProgramId = 2, CustomerId = 2, PurchaseDate = DateTime.Parse("2023-09-01"), Rating = 2 }
        });
    }
    
}