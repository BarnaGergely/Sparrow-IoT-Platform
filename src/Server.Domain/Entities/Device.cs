namespace Server.Domain.Entities;
public record Device
{
    public int Id { get; set; }

    //Mapping constraint majd kikényszeríti, hogy null ne mehessen be, így a modellnek nem kell vele foglalkoznia
    public string Name { get; set; } = null!;

    //Navigation property, nem kell mappelni, ha Include<T>-vel kérsz ki a DB contextből, akkor join meg fog történni
    //EF ajánlás hogy Collection legyen by defult inicializálva egy HashSet-re.
    public ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
}
