## Notes

### TODO: Use Unit of Work pattern

### MediatR

Not using it right now, because: https://stackoverflow.com/questions/50663501/mediatr-when-and-why-i-should-use-it

### Architecture

- [https://wkrzywiec.medium.com/ports-adapters-architecture-on-example-19cab9e93be7](https://wkrzywiec.medium.com/ports-adapters-architecture-on-example-19cab9e93be7)


I want to create an ASP.NET REST API Post endpoint that only has a data property witch can be int, float or string and I want to store it in a sqlite database. What model classes (records) and data binding should I use? Does is solvable with c# generics?

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

I want to create model classes for a databases, witch can store int, float or string values. The probles is, I want to create a generic interface for them. How can I do that?

Szeretnek egy ehhez hasonlo post requestek elt'rol's'ra alkalmas REST API/t kesziteni ASP.NET-el, de elakadtam. A problemam hogy nem tudom milyen modell osztalyokat lenne erdemes letre hozni amik kepesek tobbfele tipust kezelni es adatbazisban eltarolhatok.

```json
{
  "time": "13:05",
  "SensorValues": [
    {"sensorId": 1, "value": 0.5},
    {"sensorId": 2, "value": 1},
    {"sensorId": 12, "value": "true"}
  ] 
}
```

Polimorfizmussal es generikusokkal lehetne szerintem szepen megoldani, de nem jottem meg ra a megoldasra.

```c#

```
