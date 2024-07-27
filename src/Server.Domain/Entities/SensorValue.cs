namespace Server.Domain.Entities;

// TODO: Null checking
public abstract class SensorValue
{
    public int Id { get; set; }
    public abstract object Value { get; set; }
}

public class SensorValue<T> : SensorValue
{
    public T ValueTyped { get; set; }
    public override object Value { get => ValueTyped; set => ValueTyped = (T)value; }
}
