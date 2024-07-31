namespace DevTest;

using Microsoft.EntityFrameworkCore;

public class TestingContext : DbContext
{
    public DbSet<DeviceV3> Devices { get; set; }
    public DbSet<SensorV3> Sensors { get; set; }
    public DbSet<SensorValueV3> SensorValues { get; set; }
    public DbSet<SensorValueV3IntNumber> SensorValuesInt { get; set; }
    public DbSet<SensorValueV3FloatNumber> SensorValuesFloat { get; set; }
    public string DbPath { get; }

    public TestingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}