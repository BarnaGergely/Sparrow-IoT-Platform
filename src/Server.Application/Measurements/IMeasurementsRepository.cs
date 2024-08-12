using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;

namespace Server.Application.Measurements;

public interface IMeasurementsRepository
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
