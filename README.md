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
* .NET 11+
* MAUI
### Speicheung
* SQLlite
## Implementation
Following components/assemblies will be created:
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

#### Model-Klassen
##### DoenerBase
Basisklasse aller Model-Klassen
###### Properties
**Id** [int] - Autoincrement, PrimaryKey

**ChangeDate** [DateTime] - Wird von DbContext gesetzt

**CreationDate** [DateTime] - Wird von DbContext gesetzt
##### DoenerBistro
**Name** [string]

**Address** [Address] - wird nicht direkt gespeichert, sondern auf die Spalten AddressStreet, AddressHouseNr, AddressZip, AddressCity, AddressLat, AddressLong abgebildet ([Ignore])

#### DbContext

### DA.Doener247.MAUI


## Bemerkungen
1. all times in UTC
2. Code-Comments in german language