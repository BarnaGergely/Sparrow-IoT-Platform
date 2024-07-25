using Server.Domain.Entities;

public interface IAddDataCommandHandler
{
    void Handle(AddDeviceDataRequest command);
}