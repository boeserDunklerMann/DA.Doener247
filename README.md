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
##### Bewertung
Die eigentliche Bewertung des Produktes

###### BewertungsItem.Fleisch
Fleischqualität – 20 Punkte
- Fleischqualität und Fleischsorte
- Geschmack und Würzung
- Saftigkeit
- Knusprigkeit und Röstaromen
- Verhältnis von Fleisch zu Fett
###### BewertungsItem.Brot
Brot – 10 Punkte
- Frische und Qualität
- Knusprigkeit außen
- Weichheit innen
- Geschmack
- Stabilität: Hält das Brot den Inhalt zusammen?
###### BewertungsItem.Salat
Salat und Gemüse – 10 Punkte
- Frische und Knackigkeit
- Qualität der Zutaten
- Geschmack
- Ausgewogenheit
- Keine wässrigen oder welken Zutaten
###### BewertungsItem.Sosse
Soßen – 10 Punkte
- Geschmack und Würzung
- Cremigkeit und Konsistenz
- Qualität und Eigenständigkeit
- Menge
- Zusammenspiel mit Fleisch und Gemüse
###### BewertungsItem.Zutaten
Zusammenspiel der Zutaten – 10 Punkte
- Ausgewogenheit aller Bestandteile
- Richtige Verteilung der Zutaten
- Kein Bestandteil dominiert unangemessen
- Jeder Bissen bietet eine gute Mischung
###### BewertungsItem.Portionsgreosse
Portionsgröße – 10 Punkte
- Menge des Fleisches
- Gesamtmenge
- Sättigungsgrad
- Angemessenheit der Portion
###### BewertungsItem.Zubereitung
Zubereitung – 10 Punkte
- Richtige Temperatur
- Frische Zubereitung
- Fleisch nicht trocken oder verbrannt
- Brot richtig getoastet
- Sorgfältiges Befüllen
###### BewertungsItem.Hygiene
Hygiene und Sauberkeit – 5 Punkte
- Sauberkeit des Verkaufsbereichs
- Saubere Arbeitsgeräte
- Hygienischer Umgang mit Lebensmitteln
###### BewertungsItem.PreisLeistung
Preis-Leistungs-Verhältnis – 10 Punkte
- Preis im Verhältnis zur Qualität
- Preis im Verhältnis zur Portionsgröße
- Angemessenheit gegenüber vergleichbaren Angeboten
###### BewertungsItem.Gesamteindruck
Gesamteindruck – 5 Punkte
- Würde man ihn wieder kaufen?
- Bleibt der Geschmack positiv in Erinnerung?
- Wie überzeugend ist das Gesamterlebnis?
- Stempel- oder Rabattkarte

###### Bewertungsskala
Gesamtpunktzahl:	Bewertung
- 90–100:	Herausragend
- 80–89:	Sehr gut
- 70–79:	Gut
- 60–69:	Durchschnittlich
- 50–59:	Unterdurchschnittlich
- Unter 50:	Schwach

### DA.Doener247.SQliteAccess
.NET 11+ (läuft nur auf MAUI-Client)
#### DbContext

`await db.CreateTableAsync<Bewertung>(CreateFlags.ImplicitPK);`

### DA.Doener247.MAUI


## Bemerkungen
1. Code-Comments in german language
### Gemeinsame .Model-Assembly für Client und Server
Deswegen müssen serverseitig mit EF-Core per FluentAPI/in OnModelCreating die PKs definiert werden.
