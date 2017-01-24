using System;
using AuthorityGames.DAL.Models;

namespace AuthorityGames.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork, IDisposable
    {
		#region Fields
		private bool disposed = false;
		private IAppDbContext _dbContext;
		private IRepository<GameBattleshipMatch> _gameBattleshipMatchRepository;
		private IRepository<ShipType> _shipTypesRepository;
		private IRepository<User> _userRepository;
		private IRepository<UserMatchHistory> _userMatchHistoryRepository;
		private IRepository<UserApiKey> _userApiKeyRepository;
		#endregion

		#region Constructors
		public UnitOfWork(IAppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		#endregion

		#region Properties
		public IRepository<GameBattleshipMatch> GameBattleshipMatchRepository
		{
			get
			{
				if (_gameBattleshipMatchRepository == null)
				{
					_gameBattleshipMatchRepository = new Repository<GameBattleshipMatch>(_dbContext);
				}

				return _gameBattleshipMatchRepository;
			}
		}

		public IRepository<ShipType> ShipTypesRepository
		{
			get
			{
				if (_shipTypesRepository == null)
				{
					_shipTypesRepository = new Repository<ShipType>(_dbContext);
				}

				return _shipTypesRepository;
			}
		}

		public IRepository<User> UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new Repository<User>(_dbContext);
				}

				return _userRepository;
			}
		}

		public IRepository<UserMatchHistory> UserMatchHistoryRepository
		{
			get
			{
				if (_userMatchHistoryRepository == null)
				{
					_userMatchHistoryRepository = new Repository<UserMatchHistory>(_dbContext);
				}

				return _userMatchHistoryRepository;
			}
		}

		public IRepository<UserApiKey> UserApiKeyRepository
		{
			get
			{
				if (_userApiKeyRepository == null)
				{
					_userApiKeyRepository = new Repository<UserApiKey>(_dbContext);
				}

				return _userApiKeyRepository;
			}
		}
		#endregion

		#region Methods
		public void Save()
		{
			_dbContext.SaveChanges();
		}
		#endregion

		#region IDisposable Implementation
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed && disposing)
			{
				_dbContext.Dispose();
			}

			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
