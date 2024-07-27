using System.ComponentModel.DataAnnotations;
namespace Server.Domain.Entities;
public record Device
{
    [Key]
    [Required]
    public required Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Sensor> Sensors { get; set; }
}