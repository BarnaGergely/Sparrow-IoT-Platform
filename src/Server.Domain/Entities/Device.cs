namespace Server.Domain.Entities;
public record Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Sensor> Sensors { get; set; }
}