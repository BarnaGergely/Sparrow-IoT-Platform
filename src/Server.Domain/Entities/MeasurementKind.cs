namespace Server.Domain.Entities;
public enum MeasurementKind
{
    Temperature, //Kelvinben tárolás és konverzió extension metódusokkal
    Boolean,
    Percentage, // 0 és 1 közé normalizált érték
    Integer, //2^52-ig a double egzaktul pontosan tárolja az integert
}