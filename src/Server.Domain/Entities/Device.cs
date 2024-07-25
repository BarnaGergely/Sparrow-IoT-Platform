namespace Server.Domain.Entities;
public record Device
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }

    public Device(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}