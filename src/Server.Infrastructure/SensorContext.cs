using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;

namespace Server.Infrastructure;

public class DeviceContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<SensorValue> SensorValues { get; set; }
    public string DbPath { get; }


    public DeviceContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Sensors.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // use in memory test db
        options.UseSqlite($"Data Source={DbPath}");
    }
}
