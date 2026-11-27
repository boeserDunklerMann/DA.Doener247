# DA.Doener247
**English version coming soon.**

Android-App zur Bewertung von Döner-Kebap-Produkten, gestaffelt nach Bistro.

# Planung
## Einführung
### Zweck
Tool zur Dokumentation und Veröffentlich von Bewertungen (Retensionen) von Dönere-Kebap-Produkten
### Ziel
Ziel ist es, eine Android-App zu erstellen, mit der man Döner-Kebap nach vielfältigen Gesichtspunkten bewerten kann.

## Platform und Abhängigkeiten
### Frameworks
* .NET 11+ (außer DA.Doener247.Model, da Lauffähigkeit auf älteren Raspberry PI Modellen gewährleistet sein muss)
* MAUI
### Speicherung
* SQLlite
## Implementation
Folgende Komponenten/Assemblies werden erstellt, folgend eine kurze Erläuterung:
### DA.Doener247.Model
#### Interfaces
#### structs
##### Address
Repräsentiert eine deutsche Adressangabe mit Geolocation

**Street** [string]

**HouseNr** [string] - incl. Hausnr.-Zusatz (bspw.: a/b/c, oder Hinterhaus)

**Zip** [string] - nur 5 Ziffern

**City** [string]

**Lat** [double?] - Breitengrad (WGS84)

**Long** [double?] - Längengrad (WGS84)
#### Enum
##### FleischArt
**Kalb**

**Gefluegel**

**gemischt**
##### VerzehrArt
**ZumMitnehmen**

**VorOrt**
##### ProduktArt
Es muss nicht immer Döner sein, oftmals wird in Bistros mehr angeboten:
**Doener**

**DoenerVeetarisch** - mit Quietschkäse

**DoenerVegan** - mit Seitan

**DoenerTeller**

**DoenerBox**

**Dueruem**

**Lahmcun**

**sonstige** - z.B. Burger, Döner-Hawaii, etc. näher spezifizieren im Freitext

#### Model-Klassen
##### DoenerBase
Basisklasse aller Model-Klassen

**Id** [int] - AutoGuid(increment), PrimaryKey - Guid als Primary Key ist performancemäßig suboptimal

**ChangeDate** [DateTime] - Wird von DbContext gesetzt

**CreationDate** [DateTime] - Wird von DbContext gesetzt

**SyncDate** [DateTime?] - Wann wurde Datensatz zum Server synched, oder `null` wenn noch gar nicht
###### Methoden
`static DoenerBase Create<T>()` - erzeugt ein neues DoenerBase-object

##### DoenerBistro
**Name** [string]

**Address** [Address] - wird nicht direkt gespeichert, sondern auf die Spalten AddressStreet, AddressHouseNr, AddressZip, AddressCity, AddressLat, AddressLong abgebildet ([Ignore])
##### Sosse
Da die Soßen fluktuierend sind, speichern wir die separat in einer Klasse in der DB. Konfiguration über Settings-Page mgl.

**Bezeichnung** [string]
##### Salat
Fluktuierend wie `Sosse`

** Bezeichnung** [string]

##### DoenerKebap
Das eigentliche Döner-Produkt
**Fleisch** [FleischArt]

**Sossen** [List<Sosse>]

**Salat** [List<Salat>]

**Verzehr** [VerzehrArt]

**ProduktArt** [ProduktArt]

**Bemerkung** [string?]

**Bistro** [DoenerBistro] - das Bistro

### DA.Doener247.SQliteAccess
.NET 11+ (läuft nur auf MAUI-Client)
#### DbContext

`await db.CreateTableAsync<Bewertung>(CreateFlags.ImplicitPK);`

### DA.Doener247.MAUI


## Bemerkungen
1. Code-Comments in german language
### Gemeinsame .Model-Assembly für Client und Server
Deswegen müssen serverseitig mit EF-Core per FluentAPI/in OnModelCreating die PKs definiert werden.
