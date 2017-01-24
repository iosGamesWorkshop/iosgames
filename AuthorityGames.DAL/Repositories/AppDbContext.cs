using System.Data.Entity;
using AuthorityGames.DAL;
using AuthorityGames.DAL.Models;

namespace AuthorityGames.Domain.DAL.Repositories
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		#region Constructors
		public AppDbContext() : base("DefaultConnection")
		{
		}
		#endregion

		#region Properties
		public IDbSet<GameBattleshipMatch> GameBattleshipMatches { get; set; }
		public IDbSet<ShipType> ShipTypes { get; set; }
		public IDbSet<User> Users { get; set; }
		public IDbSet<UserMatchHistory> UserMatchHistories { get; set; }
		public IDbSet<UserApiKey> UserApiKeys { get; set; }
		#endregion

		#region Methods
		#endregion
	}
}
