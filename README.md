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
#### Model-Klassen
##### DoenerBase
Basisklasse aller Model-Klassen

**Id** [Guid] - AutoGuid(increment), PrimaryKey

**ChangeDate** [DateTime] - Wird von DbContext gesetzt

**CreationDate** [DateTime] - Wird von DbContext gesetzt
##### DoenerBistro
**Name** [string]

**Address** [Address] - wird nicht direkt gespeichert, sondern auf die Spalten AddressStreet, AddressHouseNr, AddressZip, AddressCity, AddressLat, AddressLong abgebildet ([Ignore])
##### DoenerKebap
**Fleisch** [FleischArt]

**Sossen** [tbd]

**Salat** [tbd]

**Verzehr** [VerzehrArt]

**BistroID** [int] - ForeignKey auf Id des Bistros

#### DbContext

### DA.Doener247.MAUI


## Bemerkungen
1. Code-Comments in german language