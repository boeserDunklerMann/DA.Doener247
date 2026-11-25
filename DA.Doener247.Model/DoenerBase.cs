using SQLite;

namespace DA.Doener247.Model
{
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public class DoenerBase
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public DateTime ChangeDate { get; set; }
		public DateTime CreationDate { get; set; }
	}
}