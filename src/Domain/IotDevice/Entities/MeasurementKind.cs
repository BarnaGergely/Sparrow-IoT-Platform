namespace Domain.IotDevice.Entities;
public enum MeasurementKind
{
    Temperature = 0, //Kelvinben tárolás és konverzió extension metódusokkal
    Boolean = 1,
    Percentage = 2, // 0 és 1 közé normalizált érték
    Integer = 3, //2^52-ig a double egzaktul pontosan tárolja az integert
}