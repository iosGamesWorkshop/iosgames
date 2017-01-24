using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.Domain.Helpers
{
	public class SHA256EncryptionHelper : IEncyptHelper
	{
		public string GenerateApiKey()
		{
			var key = new byte[32];
			using (var generator = RandomNumberGenerator.Create())
			{
				generator.GetBytes(key);
			}

			return Convert.ToBase64String(key);
		}

		public string GeneratPaswordSalt()
		{
			string salt;

			using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
			{
				var tokenData = new byte[32];
				rng.GetBytes(tokenData);
				salt = Convert.ToBase64String(tokenData);
			}

			return salt;
		}

		public string GetHash(string input)
		{
			var crypt = new SHA256Managed();
			var hash = new StringBuilder();
			var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
			foreach (byte theByte in crypto)
			{
				hash.Append(theByte.ToString("x2"));
			}

			return hash.ToString();
		}
	}
}
