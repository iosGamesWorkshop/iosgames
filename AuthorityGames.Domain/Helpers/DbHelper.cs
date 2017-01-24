using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorityGames.DAL;
using AuthorityGames.DAL.Models;
using AuthorityGames.Domain.Models;

namespace AuthorityGames.Domain.Helpers
{
	public class DbHelper : IDbHelper
	{
		#region Fields
		IUnitOfWork _db;
		#endregion

		#region Constructors
		public DbHelper(IUnitOfWork db)
		{
			_db = db;
		}
		#endregion

		public bool AddApiKey(int userId, string apiKey)
		{
			var dbUser = _db.UserRepository.GetById(userId);
			if (dbUser == null)
			{
				return false;
			}

			var dbSession = new UserApiKey()
			{
				UserId = userId,
				ApiKey = apiKey,
				ExpirationDateTime = DateTime.UtcNow.AddMinutes(15),
				IsActive = true,
				User = dbUser
			};

			_db.UserApiKeyRepository.Insert(dbSession);
			_db.Save();

			return true;
		}

		public bool AddNewUser(UserRegistration user)
		{
			var dbUser = new User()
			{
				UserName = user.UserName,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				PasswordHash = user.Password,
				PasswordSalt = user.Salt,
				IsActive = true,
				RegistrationDate = DateTime.UtcNow
			};

			_db.UserRepository.Insert(dbUser);
			_db.Save();

			return true;
		}

		public bool DisableApiKey(string apiKey)
		{
			var dbSession = _db.UserApiKeyRepository.Get(s => s.ApiKey == apiKey).FirstOrDefault();
			if (dbSession == null)
			{
				return false;
			}

			dbSession.IsActive = false;
			_db.UserApiKeyRepository.Update(dbSession);
			_db.Save();

			return true;
		}

		public string GetSaltForUser(string username)
		{
			var dbUser = _db.UserRepository.Get(u => u.UserName == username).FirstOrDefault();
			if (dbUser == null)
			{
				return null;
			}

			return dbUser.PasswordSalt;
		}

		public UserSession GetUserFromApiKey(string apikey)
		{
			var dbSession = _db.UserApiKeyRepository.Get(s => s.ApiKey == apikey).FirstOrDefault();
			if (dbSession == null)
			{
				return null;
			}

			var dbUser = _db.UserRepository.GetById(dbSession.UserId);
			if (dbUser == null)
			{
				return null;
			}

			return new UserSession()
			{
				ApiKey = dbSession.ApiKey,
				ExpirationDateTime = dbSession.ExpirationDateTime,
				IsActive = dbSession.IsActive,
				UserName = dbUser.UserName
			};
		}

		public bool UserExist(string username)
		{
			return _db.UserRepository.Get(u => u.UserName == username).Any();
		}

		public int ValidateUser(string username, string password)
		{
			var dbUser = _db.UserRepository.Get(u => u.UserName == username && u.PasswordHash == password).FirstOrDefault();
			if (dbUser == null)
			{
				return 0;
			}

			return dbUser.Id;
		}
	}
}
