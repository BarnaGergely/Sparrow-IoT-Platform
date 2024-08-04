namespace DevTest;

using Microsoft.EntityFrameworkCore;

public class TestingContext : DbContext
{
    public DbSet<DeviceV5> Devices { get; set; }
    public DbSet<SensorV5> Sensors { get; set; }
    public DbSet<MeasureV5> Measure { get; set; }
    public DbSet<MeasureTemperatureV5> MeasureTemperature { get; set; }
    public DbSet<MeasurePercentageV5> MeasurePercentage { get; set; }
    public string DbPath { get; }

    public TestingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "iot.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<MeasureV5>()
        .HasDiscriminator()
        .HasValue<MeasureV5>("messure_base")
        .HasValue<MeasureTemperatureV5>("temperature")
        .HasValue<MeasurePercentageV5>("percentage");
}

}