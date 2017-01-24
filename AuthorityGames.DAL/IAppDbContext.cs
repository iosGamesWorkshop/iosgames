using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AuthorityGames.DAL.Models;

namespace AuthorityGames.DAL
{
	public interface IAppDbContext
    {
		#region Properties
		IDbSet<GameBattleshipMatch> GameBattleshipMatches { get; set; }
		IDbSet<ShipType> ShipTypes { get; set; }
		IDbSet<User> Users { get; set; }
		IDbSet<UserMatchHistory> UserMatchHistories { get; set; }
		IDbSet<UserApiKey> UserApiKeys { get; set; }
		#endregion

		#region Methods
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		int SaveChanges();
		void Dispose();
		#endregion
	}
}
