using SQLite;
using DA.Doener247.Model;
using System.Reflection.Metadata.Ecma335;

namespace DA.Doener247.SQliteAccess
{
	/// <ChangeLog>
	/// <Create Datum="27.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public class DbContext(string databasePath)
	{
		private SQLiteAsyncConnection? _db;

		private async Task InitAsync()
		{
			if (_db != null) return;
			_db = new SQLiteAsyncConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
			await _db.CreateTableAsync<Salat>(CreateFlags.ImplicitPK | CreateFlags.ImplicitIndex);
			await _db.CreateTableAsync<Sosse>(CreateFlags.ImplicitPK | CreateFlags.ImplicitIndex);
		}

		#region TableGetter-methods
		public async Task<List<Salat>> GetSalatsAsync()
		{
			await InitAsync();
			return await _db!.Table<Salat>().ToListAsync();
		}

		public async Task<List<Sosse>> GetSossenAsync()
		{
			await InitAsync();
			return await _db!.Table<Sosse>().ToListAsync();
		}
		#endregion

		public async Task<int> SaveAsync(DoenerBase entry)
		{
			await InitAsync();
			// TODO DA: hier ChangeDate pflegen
			if (entry.CreationDate.HasValue)
			{
				// wurde schonmal gespeichert -> Update & ChangeDate
				entry.ChangeDate = DateTime.UtcNow;
				return await _db!.UpdateAsync(entry);
			}
			else
			{
				// ist neu -> Insert & CreationDate & ChangeDate
				entry.ChangeDate = entry.CreationDate = DateTime.UtcNow;
				return await _db!.InsertAsync(entry);
			}
		}

		public async Task<int>DeleteAsync(DoenerBase entry)
		{
			await InitAsync();
			return await _db!.DeleteAsync(entry);
		}
	}
}