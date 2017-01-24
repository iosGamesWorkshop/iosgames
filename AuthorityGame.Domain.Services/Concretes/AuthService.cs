using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.Domain;
using AuthorityGames.Domain.Models;

namespace AuthorityGame.Domain.Services.Concretes
{
	public class AuthService : IAuthService
	{
		#region Fields
		IDbHelper _dbHelper;
		IEncyptHelper _encryptHelper;
		#endregion

		#region Constructors
		public AuthService(IDbHelper dbHelper, IEncyptHelper encryptHelper)
		{
			_dbHelper = dbHelper;
			_encryptHelper = encryptHelper;
		}
		#endregion

		#region Methods
		public ServiceResult RegisterNewUser(UserRegistration user)
		{
			try
			{
				if (_dbHelper.UserExist(user.UserName))
				{
					return new ServiceResult("User with same name allready exist.");
				}

				user.Salt = _encryptHelper.GeneratPaswordSalt();
				user.Password = _encryptHelper.GetHash(user.Salt + user.Password);

				if (!_dbHelper.AddNewUser(user))
				{
					return new ServiceResult("Failed to add new user.");
				}

				return new ServiceResult(true);
			}
			catch (Exception ex)
			{
				// TO DO !!! Log appropriate message here !!!
				return new ServiceResult(false);
			}
		}

		public string ValidateUser(string username, string password)
		{
			try
			{
				var salt = _dbHelper.GetSaltForUser(username);
				password = _encryptHelper.GetHash(salt + password);
				var userId = _dbHelper.ValidateUser(username, password);
				if (userId == 0)
				{
					return null;
				};

				var apiKey = _encryptHelper.GenerateApiKey();
				_dbHelper.AddApiKey(userId, apiKey);

				return apiKey;
			}
			catch (Exception ex)
			{
				// TO DO !!! Log appropriate message here !!!
				return null;
			}

		}

		public ClaimsPrincipal GetUserFromApiKey(string apiKey)
		{
			try
			{
				var userSession = _dbHelper.GetUserFromApiKey(apiKey);
				if (userSession == null || !userSession.IsActive || userSession.ExpirationDateTime < DateTime.UtcNow)
				{
					return null;
				}

				return new ClaimsPrincipal(new GenericIdentity(userSession.UserName, "stateless"));
			}
			catch (Exception ex)
			{
				// TO DO !!! Log appropriate message here !!!
				return null;
			}
		}

		public ServiceResult DisableApiKey(string apiKey)
		{
			try
			{
				if (!_dbHelper.DisableApiKey(apiKey))
				{
					return new ServiceResult("Failed to disable apiKey.");
				}

				return new ServiceResult(true);
			}
			catch (Exception ex)
			{
				// TO DO !!! Log appropriate message here !!!
				return new ServiceResult(false);
			}
		}
		#endregion
	}
}
