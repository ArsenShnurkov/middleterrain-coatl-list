using System;
using System.Security.Cryptography;

namespace middleterraincoatllist
{
	class SessionId {
		internal const string Prefix = "((";
		internal const string Postfix = "))";
		internal const int IdLength = 4;
		const int half_len = IdLength / 2;
		static RandomNumberGenerator rng = RandomNumberGenerator.Create ();

		internal static string Create ()
		{
			byte[] key = new byte [half_len];

			lock (rng) {
				rng.GetBytes (key);
			}
			return SessionUtils.GetHexString (key);
		}

	}
}

