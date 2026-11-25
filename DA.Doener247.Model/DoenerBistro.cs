using SQLite;

namespace DA.Doener247.Model
{
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// <Change Datum="25.11.2026" Entwickler="DA" Beschreibung="Address auf einzelne Spalten abgebildet (sqlite-net)" />
	/// </ChangeLog>
	public class DoenerBistro : DoenerBase
	{
		public string Name { get; set; } = string.Empty;

		// Persistierte Adressspalten (sqlite-net kann keine eingebetteten Typen speichern)
		public string? AddressStreet { get; set; }
		public string? AddressHouseNr { get; set; }
		public string? AddressZip { get; set; }
		public string? AddressCity { get; set; }
		public double? AddressLat { get; set; }
		public double? AddressLong { get; set; }

		/// <summary>
		/// Komfort-Zugriff auf die Adresse. Wird nicht persistiert, sondern liest/schreibt die Address*-Spalten.
		/// Hinweis: Da Address eine struct ist, immer die komplette Adresse zuweisen.
		/// </summary>
		[Ignore]
		public Address Address
		{
			get => new()
			{
				Street = AddressStreet,
				HouseNr = AddressHouseNr,
				Zip = AddressZip,
				City = AddressCity,
				Lat = AddressLat,
				Long = AddressLong
			};
			set
			{
				AddressStreet = value.Street;
				AddressHouseNr = value.HouseNr;
				AddressZip = value.Zip;
				AddressCity = value.City;
				AddressLat = value.Lat;
				AddressLong = value.Long;
			}
		}
	}
}