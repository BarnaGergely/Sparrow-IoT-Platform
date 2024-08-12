using Microsoft.EntityFrameworkCore;
using Server.Application.Measurements;
using Server.Domain.Entities;

namespace Server.Infrastructure;

public class MeasurementsRepository : IMeasurementsRepository
{
    private readonly MeasurementsContext _context;

    public MeasurementsRepository(MeasurementsContext context)
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
