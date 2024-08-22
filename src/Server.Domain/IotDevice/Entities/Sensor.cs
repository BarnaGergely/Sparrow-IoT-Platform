namespace Server.Domain.Entities;
public class Sensor
{
    public int Id { get; set; }

    //Mapping constraint majd kikényszeríti, hogy null ne mehessen be, így a modellnek nem kell vele foglalkoznia
    public string Name { get; set; } = null!;

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //EF ajánlás hogy Collection legyen by defult inicializálva egy HashSet-re.
    public ICollection<Measurement> Measurments { get; set; } = new HashSet<Measurement>();
    public MeasurementKind Kind { get; set; }

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //Ő viszont lehet null, mert nem biztos, hogy kikéred include-al
    public Device? Device { get; set; }

    //Külső kulcs alapú navigation property, ha később úgy döntenél, hogy a kikért adatok alapján egy másik querty-t futtatnál
    //Szintén nem kell mappelni
    public int DeviceId { get; set; }
}