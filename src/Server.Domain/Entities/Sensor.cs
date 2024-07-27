using System.ComponentModel.DataAnnotations;
namespace Server.Domain.Entities;

public class Sensor {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    //public required Device Device { get; set; }
    public required IEnumerable<SensorValue> Values { get; set; }
}