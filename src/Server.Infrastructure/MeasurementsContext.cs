using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;

namespace Server.Infrastructure;

public class MeasurementsContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    private string DbPath { get; set; }

    public MeasurementsContext() : base()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "iot.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>().HasData(
            new Device { Id = 1, Name = "Device 1" },
            new Device { Id = 2, Name = "Device 2" }
        );
        modelBuilder.Entity<Sensor>().HasData(
            new Sensor { Id = 1, Name = "Sensor 1", DeviceId = 1, Kind = MeasurementKind.Temperature },
            new Sensor { Id = 2, Name = "Sensor 2", DeviceId = 1, Kind = MeasurementKind.Percentage},
            new Sensor { Id = 3, Name = "Sensor 3", DeviceId = 2, Kind = MeasurementKind.Integer }
        );
        modelBuilder.Entity<Measurement>().HasData(
            new Measurement { Id = 1, SensorId = 1, Value = 24.8f },
            new Measurement { Id = 2, SensorId = 1, Value = 12.0f },
            new Measurement { Id = 3, SensorId = 2, Value = 0.48f },
            new Measurement { Id = 4, SensorId = 2, Value = 0.897f },
            new Measurement { Id = 5, SensorId = 3, Value = 12 },
            new Measurement { Id = 6, SensorId = 3, Value = 19876 }
        );
    }
}
