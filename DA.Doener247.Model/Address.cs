using System;
using System.Collections.Generic;
using System.Text;

namespace DA.Doener247.Model
{
	/// <summary>
	/// Deutsche Adressangabe mit optionaler Geolocation.
	/// Wird nicht direkt persistiert, sondern von den Model-Klassen auf einzelne Spalten abgebildet.
	/// </summary>
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// <Change Datum="25.11.2026" Entwickler="DA" Beschreibung="Lat/Long als double, Strings nullable" />
	/// </ChangeLog>
	public struct Address
	{
		public string? Street { get; set; }
		/// <summary>Hausnummer inkl. Zusatz (bspw. a/b/c oder Hinterhaus)</summary>
		public string? HouseNr { get; set; }
		/// <summary>Postleitzahl, nur 5 Ziffern</summary>
		public string? Zip { get; set; }
		public string? City { get; set; }
		/// <summary>Breitengrad (WGS84)</summary>
		public double? Lat { get; set; }
		/// <summary>Längengrad (WGS84)</summary>
		public double? Long { get; set; }
	}
}
