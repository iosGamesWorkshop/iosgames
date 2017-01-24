using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityGames.Domain
{
    public interface IEncyptHelper
    {
		#region Methods
		string GenerateApiKey();
		string GeneratPaswordSalt();
		string GetHash(string input);
		#endregion
	}
}
