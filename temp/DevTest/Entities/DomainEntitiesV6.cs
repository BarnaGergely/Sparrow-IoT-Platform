namespace DevTest;

public class Device
{
    public int Id { get; set; }

    //Mapping constraint majd kikényszeríti, hogy null ne mehessen be, így a modellnek nem kell vele foglalkoznia
    public string Name { get; set; } = null!;

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //EF ajánlás hogy Collection legyen by defult inicializálva egy HashSet-re.
    public ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
}



public class Sensor
{
    public int Id { get; set; }

    //Mapping constraint majd kikényszeríti, hogy null ne mehessen be, így a modellnek nem kell vele foglalkoznia
    public string Name { get; set; } = null!;

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //EF ajánlás hogy Collection legyen by defult inicializálva egy HashSet-re.
    public ICollection<Measurment> Measurments { get; set; } = new HashSet<Measurment>();

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //Ő viszont lehet null, mert nem biztos, hogy kikéred include-al
    public Device? Device { get; set; }

    //Külső kulcs alapú navigation property, ha később úgy döntenél, hogy a kikért adatok alapján egy másik querty-t futtatnál
    //Szintén nem kell mappelni
    public int DeviceId { get; set; }
}



public class Measurment
{
    public int Id { get; set; }

    // Time when the data was measured by the sensor, if the sensor has specified it
    public DateTime? MeasurmentTime { get; set; }

    // Time when the data was received by the REST API
    public DateTime ReceptionTime { get; set; }

    public double Value { get; set; }

    public MeasurmentKind Kind { get; set; }

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //lehet null, mert nem biztos, hogy kikéred include-al
    public Sensor? Sensor { get; set; }

    //Külső kulcs alapú navigation property, ha később úgy döntenél, hogy a kikért adatok alapján egy másik querty-t futtatnál
    //Szintén nem kell mappelni
    public int SensorId { get; set; }
}

//Enum-ot az EF integernek kezel a DB-be. A kódod meg majd eldönti hogy mit kezd vele. Pl. Extension metódusokkal később
//Lásd lentebbi osztály
public enum MeasurmentKind
{

    Temperature, //Kelvinben tárolás és konverzió extension metódusokkal

    Boolean,

    Percentage, // 0 és 1 közé normalizált érték

    Integer, //2^52-ig a double egzaktul pontosan tárolja az integert
}

public static class MeasurmentExtensions
{
    //2^52-ig pontos csak, a double to int konverzió
    private static readonly double _accurateIntMaxValue = Math.Pow(2, 52);
    public static bool ToBoolean(this Measurment measurment)
    {
        if (measurment.Kind != MeasurmentKind.Boolean)
            throw new InvalidOperationException("Measurment kind is not an Boolean");

        //C style logic. Minden ami nem 0 az igaz. Ideálisan 0 és 1 fog bekerülni úgy is ilyen mérésnél
        //Tudom hogy egztakt összehasonlítás a 0-ra, meg lehet kerekítési hiba, de a 0 pontosan ábrázolható double-be is
        return measurment.Value != 0;
    }

    public static int ToInteger(this Measurment measurment)
    {
        if (measurment.Kind != MeasurmentKind.Integer)
            throw new InvalidOperationException("Measurment kind is not an Integer");
        
        //2^52-ig pontos, annál nagyobb értéket meg úgy se fogsz tárolni IoT környezetben
        //TODO: does it needed to check the data here?
        if (Math.Abs(measurment.Value) > _accurateIntMaxValue)
            throw new InvalidOperationException("The value is too big, it can be inacurate");
        
        return (int)measurment.Value;
    }

    public static double ToPercentage(this Measurment measurment)
    {
        if (measurment.Kind != MeasurmentKind.Percentage)
            throw new InvalidOperationException("Measurment kind is not a Percentage");

        // TODO: does it needed to check the data is between 0 and 1 here?
        if (measurment.Value > 0 || measurment.Value < 1)
            throw new InvalidOperationException("Percentage value is not between 0 and 1");

        //0 és 1 közé normalizált érték
        return measurment.Value;
    }
}