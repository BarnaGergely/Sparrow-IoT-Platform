# IoT Server Notes

## Tutorials

- Angular
    - Acourse made by the developers, good start: [https://angular.io/tutorial/tour-of-heroes](Tour of Heroes)
    - [https://www.youtube.com/playlist?list=PLC3y8-rFHvwhBRAgFinJR8KHIrCdTkZcZ](Basic teories)
    - Maximilian Udemy are good
- Integrate angular with asp.net core
    - [https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-angular?view=vs-2022] by Microsoft
    - [https://youtu.be/fqR-WbmX8PM?si=s8kJlPSWl4oSX2GL](Youtube 6 moths ago)

## Problems

### Modell classes

A sensor data tarolasara tervezett modell osztalyok problemasak. Json Serializer nem tamogatja a generikusokat, polimorfizmust sem ugy ahogy nekem kene. A leghatekonyabb megoldas az lenne, ha irnak sajat convertert, de ez eleg komplikalt. Egyenlore megprobalom sima object kent eltarolni a json-t es kesobb cast-olni.

## Tasks
- Irnom kell egy sajat Json Convertert:
  - https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-8-0#support-polymorphic-deserialization
  - https://www.reddit.com/r/csharp/comments/1ecqxse/what_c_entities_should_i_create_to_store_a/
- Create Device REST API
  - Create Model records
    - Entity framework friendly design: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/creating-model-classes-with-the-entity-framework-cs
    - Property vs Constructor
    - id vs list - relationships: https://learn.microsoft.com/en-us/ef/core/modeling/relationships
    - polymoirph data storing
    - Can I let models be changable?
  - Learn how to manage db with Entity framework efficiently
  - create REST endpoint
    - optional properties
    - data binding

## Notes

### TODO: Use Unit of Work pattern

### MediatR

Not using it right now, because: [https://stackoverflow.com/questions/50663501/mediatr-when-and-why-i-should-use-it](https://stackoverflow.com/questions/50663501/mediatr-when-and-why-i-should-use-it)

### Architecture

- [https://wkrzywiec.medium.com/ports-adapters-architecture-on-example-19cab9e93be7](https://wkrzywiec.medium.com/ports-adapters-architecture-on-example-19cab9e93be7)

## Database and Model class plan

- Device
  - Name
  - Description
  - Id
  - Sensors list (Input variables usually)
    - Sensor
      - Name
      - Description
      - Id
      - Data type (int, double, float, string, temperature, percentage, Volt, Amper, Time, ...)
      - Datas List
        - Data
          - Value
          - DateTime
          - Id

## Questions

### Table-per-hierarchy or Table-per-type

TPH

### Where should the Id-s be created and how?

### valami

I want to create an ASP.NET REST API Post endpoint that only has a data property witch can be int, float or string and I want to store it in a sqlite database. What model classes (records) and data binding should I use? Does is solvable with c# generics?

I want to create model classes for a databases, witch can store int, float or string values. The probles is, I want to create a generic interface for them. How can I do that?

What C# Entities should I create to store jsons like this?

```json
{
  "deviceId": 12456,
  "sensorValues": [
    {"sensorId": 1, "value": 0.5},
    {"sensorId": 2, "value": 1},
    {"sensorId": 12, "value1": "Something happened!", "value2": 13},
    {"sensorId": 25, "value": 56},
    {"sensorId": 4, "value": 3.8}
  ] 
}
```

Szeretnek egy ASP.NET minimal REST API-t kesziteni IoT eszkozokkel mert adatok fogadasara. Minden eszkoznek tobb kulonbozo tipusu adatokat szolgaltato szenzora lehet pl.: egeszszam, tortszam, szazalek, szoveg, feszultseg. A jovoben bovulni fog ez a loosly typed lista.

A sensorId alapjan meg lehet mondani milyen formatumunak kellene lennie az adott objektumnak. Irhatok egy sajat Model Binder-t, de nem tudom milyen rekords kellene tarolni az adatokat.

Ha irok egy sajat Model Binder-t az elvileg meg a megfelelo formatumra is tudja konvertalni, de milyen Entity-ket kellene letre hozzak egy ilyen adat szerkezet eltarolasara?

Ez nem egy fordulo kod, de valami hasonlora lenne szerintem szuksegem.

```c#
public record Device
{
    public int Id { get; set; }
    public IEnumerable<Sensor> Sensors { get; set; } // This is not valid
}

public record Sensor<T> where T : ISensorDataType
{
    public required int Id { get; set; }
    public required Device Device { get; set; }
    public required IEnumerable<ISensorDataType> SensorValues { get; set; } // This is not valid
}

public interface ISensorDataType
{
    public object Value { get; set; }
}

public class SensorDataInt : ISensorDataType
{
    public override int Value { get; set; } // This is not valid
}

public class SensorDataString : ISensorDataType
{
    public override string Value { get; set; } // This is not valid
}
```



Szeretnek egy ehhez hasonlo post requestek eltarolasara alkalmas REST API-t kesziteni ASP.NET-el. A problemam hogy nem tudom milyen modell osztalyokat lenne erdemes letre hozni amik kepesek tobbfele tipust kezelni es adatbazisban eltarolhatok.

Az adatbazispan tipusonkent kulon tablaban szeretnem tarolni az adatokat es olyon modell osztalyokat szeretnek melyek erosen tipusosak, lejet tudni melyik rekord milyen tipusu adatot tartalmaz.

Polimorfizmussal es generikusokkal lehetne szerintem szepen megoldani, de nem jottem meg ra a megoldasra.

```c#
public record Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Sensor> Sensors { get; set; }
}

public record Sensor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Device? DeviceV3 { get; set; }
    public int DeviceId { get; set; }
    public ICollection<Measure> Measures { get; set; } = new List<Measure>();
    public string MeasureTypeName { get; set; } = typeof(Measure).Name;
}

public record Measure
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public SensorV3? SensorV3 { get; set; }
    public int SensorId { get; set; }
}

public record MeasureIntNumber : Measure
{
    public int Value { get; set; }
}

public record MeasureFloatNumber : Measure
{
    public float Value { get; set; }
}
```

```c#
public record Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Sensor> Sensors { get; set; }
}

public class Sensor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Device? Device { get; set; }
    public int DeviceId { get; set; }
    public ICollection<Measure> Measures { get; set; } = new List<Measure>();
    public string SensorValueTypeName { get; set; } = typeof(Measure).Name;
}

public class Measure
{
    public int Id { get; set; }
    public virtual object Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public Sensor Sensor { get; set; }
    public int SensorId { get; set; }
}

public class Measure<T> : Measure
{
    public T ValueTyped { get; set; }
    public override object Value { get => ValueTyped; set => ValueTyped = (T)value; }
}
```
