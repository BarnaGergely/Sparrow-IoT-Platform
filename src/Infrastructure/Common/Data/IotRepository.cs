using Application.Common.Interfaces;
using Domain.IotDevice.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Data;

public class IotRepository : IIotRepository
{
    private readonly IotContext _context;

    public IotRepository(IotContext context)
    {
        _context = context;
    }

    public DbSet<Device> Devices
    {
        get => _context.Devices;
        set => _context.Devices = value;
    }
    public DbSet<Sensor> Sensors
    {
        get => _context.Sensors;
        set => _context.Sensors = value;
    }
    public DbSet<Measurement> Measurements
    {
        get => _context.Measurements;
        set => _context.Measurements = value;
    }

    public int SaveChanges() => _context.SaveChanges();


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
