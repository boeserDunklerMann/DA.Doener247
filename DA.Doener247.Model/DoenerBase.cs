namespace DA.Doener247.Model
{
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// <Change Datum="27.11.2026" Entwickler="DA">add method Create</Change>
	/// </ChangeLog>
	public class DoenerBase
	{
		public Guid Id { get; set; }
		/// <remarks>will be set in call to Save(Async)</remarks>
		public DateTime? ChangeDate { get; set; }
		/// <remarks>will be set in call to Save(Async)</remarks>
		public DateTime? CreationDate { get; set; }

		public static T Create<T>() where T : DoenerBase, new()
		{
			return new T() { Id = GuidV7.Create() };
		}
	}
}