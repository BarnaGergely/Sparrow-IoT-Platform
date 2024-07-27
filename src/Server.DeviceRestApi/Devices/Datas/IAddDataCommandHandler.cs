using Server.Domain.Entities.ApiEntities;

public interface IAddDataCommandHandler
{
    void Handle(AddDeviceDataRequest command);
}