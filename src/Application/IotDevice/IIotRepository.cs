using Domain.IotDevice.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.IotDevice;

public interface IIotRepository
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
