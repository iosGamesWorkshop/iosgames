using System.Security.Claims;
using AuthorityGames.Domain.Models;

namespace AuthorityGame.Domain.Services
{
	public interface IAuthService
    {
		#region Properties
		#endregion

		#region Methods
		ServiceResult RegisterNewUser(UserRegistration user);
		string ValidateUser(string username, string password);
		ClaimsPrincipal GetUserFromApiKey(string apiKey);
		ServiceResult DisableApiKey(string apiKey);
		#endregion
	}
}
