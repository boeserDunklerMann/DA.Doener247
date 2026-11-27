
namespace DA.Doener247.Model
{
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// <Change Datum="25.11.2026" Entwickler="DA" Beschreibung="Address auf einzelne Spalten abgebildet (sqlite-net)" />
	/// <Change Datum="27.11.2026" Entwickler="DA">add method SetAddress</Change>
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
		/// Setzt die Adresse, da der entsprechende Setter private ist, damit SQLite diese Property ignoriert.
		/// </summary>
		/// <param name="address"></param>
		public void SetAddress(Address address)
		{
			this.Address = address;
		}

		/// <summary>
		/// Komfort-Zugriff auf die Adresse. Wird nicht persistiert, sondern liest/schreibt die Address*-Spalten.
		/// Hinweis: Da Address eine struct ist, immer die komplette Adresse zuweisen.
		/// </summary>
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
			private set
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