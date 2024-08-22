namespace Server.Domain.Entities;
public class Measurement
{
    public int Id { get; set; }

    // Time when the data was measured by the sensor, if the sensor has specified it
    public DateTime? MeasurementTime { get; set; }

    // Time when the data was received by the REST API
    public DateTime ReceptionTime { get; set; }

    public double Value { get; set; }

    public MeasurementKind Kind { get; set; }

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //lehet null, mert nem biztos, hogy kikéred include-al
    public Sensor? Sensor { get; set; }

    //Külső kulcs alapú navigation property, ha később úgy döntenél, hogy a kikért adatok alapján egy másik querty-t futtatnál
    //Szintén nem kell mappelni
    public int SensorId { get; set; }
}

public static class MeasurmentExtensions
{
    //2^52-ig pontos csak, a double to int konverzió
    private static readonly double _accurateIntMaxValue = Math.Pow(2, 52);
    public static bool ToBoolean(this Measurement measurment)
    {
        if (measurment.Kind != MeasurementKind.Boolean)
            throw new InvalidOperationException("Measurement kind is not an Boolean");

        //C style logic. Minden ami nem 0 az igaz. Ideálisan 0 és 1 fog bekerülni úgy is ilyen mérésnél
        //Tudom hogy egztakt összehasonlítás a 0-ra, meg lehet kerekítési hiba, de a 0 pontosan ábrázolható double-be is
        return measurment.Value != 0;
    }

    public static int ToInteger(this Measurement measurment)
    {
        if (measurment.Kind != MeasurementKind.Integer)
            throw new InvalidOperationException("Measurement kind is not an Integer");
        
        //2^52-ig pontos, annál nagyobb értéket meg úgy se fogsz tárolni IoT környezetben
        //TODO: does it needed to check the data here?
        if (Math.Abs(measurment.Value) > _accurateIntMaxValue)
            throw new InvalidOperationException("The value is too big, it can be inacurate");
        
        return (int)measurment.Value;
    }

    public static double ToPercentage(this Measurement measurment)
    {
        if (measurment.Kind != MeasurementKind.Percentage)
            throw new InvalidOperationException("Measurement kind is not a Percentage");

        // TODO: does it needed to check the data is between 0 and 1 here?
        if (measurment.Value > 0 || measurment.Value < 1)
            throw new InvalidOperationException("Percentage value is not between 0 and 1");

        //0 és 1 közé normalizált érték
        return measurment.Value;
    }
}
