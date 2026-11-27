using System.Security.Cryptography;

namespace DA.Doener247.Model
{
	/// <ChangeLog>
	/// <Create Datum="27.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	internal class GuidV7
	{
		public static Guid Create()
		{
			Span<byte> b = stackalloc byte[16];
			RandomNumberGenerator.Fill(b);

			long ms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			b[0] = (byte)(ms >> 40);
			b[1] = (byte)(ms >> 32);
			b[2] = (byte)(ms >> 24);
			b[3] = (byte)(ms >> 16);
			b[4] = (byte)(ms >> 8);
			b[5] = (byte)ms;

			b[6] = (byte)((b[6] & 0x0F) | 0x70); // Version 7
			b[8] = (byte)((b[8] & 0x3F) | 0x80); // Variante RFC 9562

			return new Guid(b, bigEndian: true);
		}
	}
}
