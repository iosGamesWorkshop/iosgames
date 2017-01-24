using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain.Models;

namespace AuthorityGames.Domain
{
    public interface IDbHelper
    {
		#region Properties
		#endregion

		#region Methods - User
		int ValidateUser(string username, string password);
		bool AddNewUser(UserRegistration user);
		UserSession GetUserFromApiKey(string apikey);
		string GetSaltForUser(string username);
		bool AddApiKey(int userId, string apiKey);
		bool DisableApiKey(string apiKey);
		bool UserExist(string username);
		#endregion
	}
}
