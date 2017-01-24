using System;

namespace AuthorityGames.DAL.Models
{
	public class UserApiKey
    {
		#region Properties
		public int Id { get; set; }
		public int UserId { get; set; }
		public string ApiKey { get; set; }
		public DateTime ExpirationDateTime { get; set; }
		public bool IsActive { get; set; }

		public User User { get; set; }
		#endregion
	}
}
