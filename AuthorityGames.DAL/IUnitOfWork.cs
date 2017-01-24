using AuthorityGames.DAL.Models;

namespace AuthorityGames.DAL
{
	public interface IUnitOfWork
    {
		#region Properties
		IRepository<GameBattleshipMatch> GameBattleshipMatchRepository { get; }
		IRepository<ShipType> ShipTypesRepository { get; }
		IRepository<User> UserRepository { get; }
		IRepository<UserMatchHistory> UserMatchHistoryRepository { get; }
		IRepository<UserApiKey> UserApiKeyRepository { get; }
		#endregion

		#region Methods
		/// <summary>
		/// Saves current unit of work to database context.
		/// </summary>
		void Save();
		#endregion
	}
}
